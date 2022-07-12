using System.Threading.Tasks;
using Bogus;
using Newtonsoft.Json;

namespace BrainRock.App.Source
{
    public class BogusApi : BogusSource
    {
        public override async Task<string> Execute()
        {
            var userFaker = new UserFaker();
            var user = userFaker.Generate();
            var json = JsonConvert.SerializeObject(user);
            return await Task.FromResult(json);
        }

        public override string ToString()
        {
            return "BogusApi";
        }

        public class User
        {
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Country { get; set; }
        }

        public class UserFaker : Faker<User>
        {
            public UserFaker() : base("ru")
            {
                RuleFor(o => o.UserName, f => f.Person.UserName);
                RuleFor(o => o.FirstName, f => f.Person.FirstName);
                RuleFor(o => o.LastName, f => f.Person.LastName);
                RuleFor(o => o.Country, f => f.Address.Country());
            }
        }
    }
}