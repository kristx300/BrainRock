using System;
using System.Threading.Tasks;
using BrainRock.Lib.Core;

namespace BrainRock.App.Source
{
    public class BogusLoremPixelImage : BogusSource
    {
        public override async Task<string> Execute()
        {
            var imageArray = await HttpWrapper.GetBytes(Faker.Image.LoremPixelUrl());
            return Convert.ToBase64String(imageArray);
        }

        public override string ToString()
        {
            return "Bogus Lorem Pixel";
        }
    }
}