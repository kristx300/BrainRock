using BrainRock.Lib.Core;
#if NET452_OR_GREATER
using System.Threading.Tasks;
#endif

namespace BrainRock.Lib.Source
{
    public abstract class HttpSource : ISource
    {
        protected HttpSource(string url)
        {
            Url = url;
        }

        protected string Url { get; set; }
#if NET35
        public virtual string Execute()
        {
            return HttpWrapper.Get(Url);
        }
#else
        public virtual async Task<string> Execute()
        {
            return await HttpWrapper.Get(Url);
        }
#endif
    }
}