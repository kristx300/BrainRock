#if NET452_OR_GREATER
using System.Threading.Tasks;
#endif

namespace BrainRock.Lib.Source
{
    public interface ISource
    {
#if NET35
        string Execute();
#else
        Task<string> Execute();
#endif
    }
}