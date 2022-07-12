namespace BrainRock.Lib.Source.Api
{
    public class Coffee : HttpSource
    {
        public Coffee() : base("https://coffee.alexflipnote.dev/random.json")
        {
        }

        public override string ToString()
        {
            return "Coffee";
        }
    }
}