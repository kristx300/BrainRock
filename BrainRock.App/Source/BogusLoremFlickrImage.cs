using System;
using System.Threading.Tasks;
using BrainRock.Lib.Core;

namespace BrainRock.App.Source
{
    public class BogusLoremFlickrImage : BogusSource
    {
        public override async Task<string> Execute()
        {
            var imageArray = await HttpWrapper.GetBytes(Faker.Image.LoremFlickrUrl());
            return Convert.ToBase64String(imageArray);
        }

        public override string ToString()
        {
            return "Bogus Lorem Flickr";
        }
    }
}