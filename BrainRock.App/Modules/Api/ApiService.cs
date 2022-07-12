using System.Collections.Generic;
using BrainRock.App.Source;
using BrainRock.Lib.Source;
using BrainRock.Lib.Source.Api;

namespace BrainRock.App.Modules.Api
{
    public interface IApiService : IService
    {
        IReadOnlyCollection<ISource> GetAllSources();
    }

    public class ApiService : IApiService
    {
        private readonly List<ISource> _sources = new List<ISource>
        {
            new Animechan(),
            new Coffee(),
            new Fox(),
            new PostmanEcho(),
            new BogusApi()
        };

        public IReadOnlyCollection<ISource> GetAllSources()
        {
            return _sources.AsReadOnly();
        }
    }
}