#if NET452_OR_GREATER
using System.Threading.Tasks;
#endif

namespace BrainRock.Lib.Source.Lorem
{
    public class Baconipsum : HttpSource
    {
        public Baconipsum() : base("https://baconipsum.com/api/?type=meat-and-filler")
        {
        }
#if NET35
        public override string Execute()
        {
            var baseResult = base.Execute();
            return baseResult.Substring(2, baseResult.Length - 4);
        }
#else
        public override async Task<string> Execute()
        {
            var baseResult = await base.Execute();
            return baseResult.Substring(2, baseResult.Length - 4);
        }
#endif
        public override string ToString()
        {
            return "Baconipsum";
        }
    }
}