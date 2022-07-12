using System.Threading.Tasks;
using BrainRock.Lib.Source.Api;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BrainRock.Tests
{
    [TestFixture]
    public class SourceTests
    {
        [Test]
        public async Task ExecuteExampleTest()
        {
            var source = new Animechan();

            var json = await source.Execute();

            Assert.IsNotNull(json);
            Assert.IsNotEmpty(json);

            var anime = JsonConvert.DeserializeObject<AnimechanModel>(json);

            Assert.IsNotNull(anime);
            Assert.IsNotEmpty(anime.Character);
            Assert.IsNotEmpty(anime.Anime);
            Assert.IsNotEmpty(anime.Quote);
        }

        public class AnimechanModel
        {
            [JsonProperty("anime")] public string Anime { get; set; }

            [JsonProperty("character")] public string Character { get; set; }

            [JsonProperty("quote")] public string Quote { get; set; }
        }
    }
}