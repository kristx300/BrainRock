using System.ServiceModel;

namespace BrainRock.Service
{
    [ServiceContract]
    public interface ISoapRock
    {
        [OperationContract]
        string GetJson(string source);

        [OperationContract]
        string GetImage(string source);

        [OperationContract]
        string GetLorem(string source);
    }

    [ServiceBehaviorAttribute(InstanceContextMode = InstanceContextMode.Single)]
    public class SoapRock : ISoapRock
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