using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using BrainRock.Lib.Source.Api;
using Newtonsoft.Json;

namespace BrainRock.Com
{
    [Guid("56E89188-2544-43D6-B965-CB5B3486357B")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Rock.ComObj")]
    public class RockObj
    {
        private readonly Animechan _animechan;

        public RockObj()
        {
            _animechan = new Animechan();
        }

        public Rock MakeRock()
        {
            var animeJson = _animechan.Execute();

            var animeObj = JsonConvert.DeserializeObject<AnimechanModel>(animeJson);

            return new Rock
            {
                Name = animeObj?.Character ?? "new Rock",
                Weight = 2464.256,
                Size = 851,
                IsCrushed = false
            };
        }

        public Rock Crush(Rock r)
        {
            r.IsCrushed = true;
            return r;
        }
    }

    public class AnimechanModel
    {
        [JsonProperty("anime")] public string Anime { get; set; }

        [JsonProperty("character")] public string Character { get; set; }

        [JsonProperty("quote")] public string Quote { get; set; }
    }

    [DataContract]
    public class Rock
    {
        [DataMember] public string Name { get; set; }

        [DataMember] public double Weight { get; set; }

        [DataMember] public double Size { get; set; }

        [DataMember] public bool IsCrushed { get; set; }
    }
}