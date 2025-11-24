namespace Domain.Tests.Common
{
    using Domain.Common;
    using NUnit.Framework;

    [TestFixture]
    public class CityResourceTest
    {
        [Test]
        public void SumTest()
        {
            var value = new CityResource(2, 2, 2);
            var incr = new CityResource(2, 2, 2);

            var result = value + incr;
            Assert.That(result.money == 4 && result.people == 4 && result.control == 4);
        }

        [Test]
        public void SubTest()
        {
            var value = new CityResource(4, 4, 4);
            var incr = new CityResource(2, 2, 2);

            var result = value - incr;
            Assert.That(result.money == 2 && result.people == 2 && result.control == 2);
        }

        [Test]
        public void EqualityTest()
        {
            var value1 = new CityResource(10, 100, 1000);
            var value2 = new CityResource(10, 100, 1000);
            var value3 = new CityResource(11, 111, 1111);
            
            Assert.IsTrue(value1 == value2);
            Assert.IsFalse(value1 == value3 || value2 == value3);
        }
    }
}