namespace BrainRock.Lib.Source.Api
{
    public class Fox : HttpSource
    {
        public Fox() : base("https://randomfox.ca/floof/")
        {
        }

        public override string ToString()
        {
            return "Fox";
        }
    }
}