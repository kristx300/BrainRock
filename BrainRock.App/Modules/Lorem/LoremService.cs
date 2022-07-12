using System.Collections.Generic;
using System.Collections.ObjectModel;
using BrainRock.App.Source;
using BrainRock.Lib.Source;
using BrainRock.Lib.Source.Lorem;

namespace BrainRock.App.Modules.Lorem
{
    public interface ILoremService : IService
    {
        IReadOnlyCollection<ISource> GetAllSources();
    }

    public class LoremService : ILoremService
    {
        private readonly List<ISource> _sources = new List<ISource>
        {
            new Baconipsum(),
            new BogusLorem()
        };

        public IReadOnlyCollection<ISource> GetAllSources()
        {
            return new ObservableCollection<ISource>(_sources);
        }
    }
}