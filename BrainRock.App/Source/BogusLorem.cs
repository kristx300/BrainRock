using System.Threading.Tasks;

namespace BrainRock.App.Source
{
    public class BogusLorem : BogusSource
    {
        public override async Task<string> Execute()
        {
            return await Task.FromResult(Faker.Lorem.Paragraph());
        }

        public override string ToString()
        {
            return "BogusLorem";
        }
    }
}