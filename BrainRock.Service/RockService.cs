using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.ServiceProcess;
using Serilog;

namespace BrainRock.Service
{
    internal partial class RockService : ServiceBase
    {
        private const int Port = 8899;
        private WebServiceHost _jsonHost;
        private ServiceHost _soapHost;

        public RockService()
        {
            InitializeComponent();

            var soapUri = new Uri($"http://localhost:{Port}/SRockService/");

            _soapHost = new ServiceHost(new SoapRock(), soapUri);

            var smb = _soapHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
            if (smb == null)
                smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            _soapHost.Description.Behaviors.Add(smb);

            _soapHost.CloseTimeout = new TimeSpan(15000);
            _soapHost.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,
                MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            var binding = new WSHttpBinding();
            binding.MaxReceivedMessageSize = 5000000;
            binding.Security.Mode = SecurityMode.None;
            _soapHost.AddServiceEndpoint(typeof(ISoapRock), binding, "");


            var urlJson = new Uri($"http://localhost:{Port}/JRockService/");
            _jsonHost = new WebServiceHost(new JsonRock(), urlJson);
            _jsonHost.AddServiceEndpoint(typeof(IJsonRock), new WebHttpBinding { MaxReceivedMessageSize = 5000000 },
                "");
        }

        public void Start()
        {
            Log.Information("Custom start");
            _soapHost.Open();

            _jsonHost.Open();
        }

        protected override void OnStart(string[] args)
        {
            Log.Information("OnStart");
            _soapHost.Open();

            _jsonHost.Open();
            Log.Information("Host is open");
        }

        protected override void OnStop()
        {
            Log.Information("OnStop");
            if (_soapHost != null)
            {
                _soapHost.Close();
                _soapHost = null;
            }

            if (_jsonHost != null)
            {
                _jsonHost.Close();
                _jsonHost = null;
            }
        }

        protected override void OnShutdown()
        {
            Log.Information("OnShutdown");
            try
            {
                _soapHost.Close();
            }
            catch
            {
                _soapHost.Abort();
            }

            try
            {
                _jsonHost.Close();
            }
            catch
            {
                _jsonHost.Abort();
            }

            base.OnShutdown();
        }
    }
}