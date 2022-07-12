using System.Threading.Tasks;
using Bogus;
using BrainRock.Lib.Source;

namespace BrainRock.App.Source
{
    public abstract class BogusSource : ISource
    {
        protected Faker Faker = new Faker("ru");
        public abstract Task<string> Execute();
    }
}