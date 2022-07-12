using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrainRock.Lib.Source;
using BrainRock.Lib.Source.Api;
using BrainRock.Lib.Source.Image;
using BrainRock.Lib.Source.Lorem;
using Coffee = BrainRock.Lib.Source.Image.Coffee;

namespace BrainRock.Service
{
    public sealed class Rock
    {
        private readonly List<ISource> _images = new List<ISource>
        {
            new Coffee(),
            new Picsum()
        };

        private readonly List<ISource> _json = new List<ISource>
        {
            new Animechan(),
            new Lib.Source.Api.Coffee(),
            new Fox(),
            new PostmanEcho()
        };

        private readonly List<ISource> _lorem = new List<ISource>
        {
            new Baconipsum()
        };

        public async Task<string> GetJson(string source)
        {
            var json =
                _json.FirstOrDefault(f => f.ToString().Equals(source, StringComparison.CurrentCultureIgnoreCase)) ??
                _json.First();
            return await json.Execute();
        }

        public async Task<string> GetImage(string source)
        {
            var image =
                _images.FirstOrDefault(f => f.ToString().Equals(source, StringComparison.CurrentCultureIgnoreCase)) ??
                _images.First();
            return await image.Execute();
        }

        public async Task<string> GetLorem(string source)
        {
            var lorem =
                _lorem.FirstOrDefault(f => f.ToString().Equals(source, StringComparison.CurrentCultureIgnoreCase)) ??
                _lorem.First();
            return await lorem.Execute();
        }
    }
}