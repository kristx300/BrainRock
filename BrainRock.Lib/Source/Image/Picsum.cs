using System;
using BrainRock.Lib.Core;
#if NET452_OR_GREATER
using System.Threading.Tasks;
#endif

namespace BrainRock.Lib.Source.Image
{
    public class Picsum : HttpSource
    {
        public Picsum() : base("https://picsum.photos/300/200")
        {
        }
#if NET35
        public override string Execute()
        {
            var imageArray = HttpWrapper.GetBytes(Url);
            return Convert.ToBase64String(imageArray);
        }
#else
        public override async Task<string> Execute()
        {
            var imageArray = await HttpWrapper.GetBytes(Url);
            return Convert.ToBase64String(imageArray);
        }
#endif

        public override string ToString()
        {
            return "Picsum";
        }
    }
}