using BrainRock.Service;
using NUnit.Framework;

namespace BrainRock.Tests
{
    [TestFixture]
    public class ServiceTests
    {
        [Test]
        public void InitJsonAndCallMethodEmptySource()
        {
            var jsonRockService = new JsonRock();

            var json = jsonRockService.GetLorem(string.Empty);

            Assert.NotNull(json);
            Assert.IsNotEmpty(json);
            TestContext.Progress.WriteLine(json);
        }

        [Test]
        public void InitJsonAndCallMethodNullSource()
        {
            var jsonRockService = new JsonRock();

            var json = jsonRockService.GetLorem(null);

            Assert.NotNull(json);
            Assert.IsNotEmpty(json);
            TestContext.Progress.WriteLine(json);
        }

        [Test]
        public void InitJsonAndCallMethodBaconipsumSource()
        {
            var jsonRockService = new JsonRock();

            var json = jsonRockService.GetLorem("Baconipsum");

            Assert.NotNull(json);
            Assert.IsNotEmpty(json);
            TestContext.Progress.WriteLine(json);
        }

        [Test]
        public void InitSoapAndCallMethodEmptySource()
        {
            var soapRockService = new SoapRock();

            var json = soapRockService.GetLorem(string.Empty);

            Assert.NotNull(json);
            Assert.IsNotEmpty(json);
            TestContext.Progress.WriteLine(json);
        }

        [Test]
        public void InitSoapAndCallMethodNullSource()
        {
            var soapRockService = new SoapRock();

            var json = soapRockService.GetLorem(null);

            Assert.NotNull(json);
            Assert.IsNotEmpty(json);
            TestContext.Progress.WriteLine(json);
        }

        [Test]
        public void InitSoapAndCallMethodBaconipsumSource()
        {
            var soapRockService = new SoapRock();

            var json = soapRockService.GetLorem("Baconipsum");

            Assert.NotNull(json);
            Assert.IsNotEmpty(json);
            TestContext.Progress.WriteLine(json);
        }
    }
}