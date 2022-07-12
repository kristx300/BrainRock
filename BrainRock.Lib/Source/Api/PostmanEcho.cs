namespace BrainRock.Lib.Source.Api
{
    public class PostmanEcho : HttpSource
    {
        public PostmanEcho() : base("https://postman-echo.com/get")
        {
        }

        public override string ToString()
        {
            return "PostmanEcho";
        }
    }
}