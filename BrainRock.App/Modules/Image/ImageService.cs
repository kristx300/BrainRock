using System.Collections.Generic;
using BrainRock.App.Source;
using BrainRock.Lib.Source;
using BrainRock.Lib.Source.Image;

namespace BrainRock.App.Modules.Image
{
    public interface IImageService : IService
    {
        IReadOnlyCollection<ISource> GetAllSources();
    }

    public class ImageService : IImageService
    {
        private readonly List<ISource> _sources = new List<ISource>
        {
            new Coffee(),
            new Picsum(),
            new BogusLoremFlickrImage(),
            new BogusLoremPixelImage()
        };

        public IReadOnlyCollection<ISource> GetAllSources()
        {
            return _sources.AsReadOnly();
        }
    }
}