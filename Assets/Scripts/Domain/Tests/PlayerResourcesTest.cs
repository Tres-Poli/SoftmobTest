namespace Domain.Tests
{
    using Domain.Common;
    using NUnit.Framework;

    [TestFixture]
    public class PlayerResourcesTest
    {
        [Test]
        public void ChangeResourceValuePositiveTest()
        {
            var initialValue = new CityResource(100, 100, 100);
            var resources = new PlayerResources(initialValue);
            
            var increment = new CityResource(-1, -52, -100);

            Assert.IsTrue(resources.TryChange(increment) && resources.resourceValue == initialValue + increment);
        }

        [Test]
        public void ChangeResourceValueNegativeTest()
        {
            var initialValue = new CityResource(100, 100, 100);
            var resources = new PlayerResources(initialValue);

            var increment = new CityResource(-101, -23422, -99922);

            Assert.That(resources.TryChange(increment) == false && resources.resourceValue == initialValue);
        }
    }
}