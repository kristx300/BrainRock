using System.ServiceModel;
using System.ServiceModel.Web;

namespace BrainRock.Service
{
    [ServiceContract]
    public interface IJsonRock
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getJson/{source}")]
        string GetJson(string source);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getImage/{source}")]
        string GetImage(string source);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getLorem/{source}")]
        string GetLorem(string source);
    }

    [ServiceBehaviorAttribute(InstanceContextMode = InstanceContextMode.Single)]
    public class JsonRock : IJsonRock
    {
        private readonly Rock _rock = new Rock();

        public string GetJson(string source)
        {
            var task = _rock.GetJson(source);
            task.Wait();
            return task.Result;
        }

        public string GetImage(string source)
        {
            var task = _rock.GetImage(source);
            task.Wait();
            return task.Result;
        }

        public string GetLorem(string source)
        {
            var task = _rock.GetLorem(source);
            task.Wait();
            return task.Result;
        }
    }
}