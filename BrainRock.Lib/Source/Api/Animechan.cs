namespace BrainRock.Lib.Source.Api
{
    public class Animechan : HttpSource
    {
        public Animechan() : base("https://animechan.vercel.app/api/random")
        {
        }

        public override string ToString()
        {
            return "Animechan";
        }
    }
}