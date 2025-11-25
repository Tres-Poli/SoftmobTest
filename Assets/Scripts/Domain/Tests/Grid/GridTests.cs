namespace Domain.Tests.Grid
{
    using Buildings;
    using Domain.Common;
    using Domain.Grid;
    using Mocks;
    using NUnit.Framework;

    [TestFixture]
    public class GridTests
    {
        [Test]
        public void IndexValidationTest()
        {
            var grid = new Grid(size: 10);
            
            var invalidIndex = new GridIndex(-1, 11);
            var invalidXIndex = new GridIndex(-1, 5);
            var invalidYIndex = new GridIndex(7, 12);

            var validIndex = new GridIndex(1, 9);

            Assert.IsFalse(grid.IsValidIndex(invalidIndex));
            Assert.IsFalse(grid.IsValidIndex(invalidXIndex));
            Assert.IsFalse(grid.IsValidIndex(invalidYIndex));
            
            Assert.IsTrue(grid.IsValidIndex(validIndex));
        }
        
    #region CRUD
        
        private BuildingData _mock1 = new(BuildingType.Main, 1, CityResource.defaultValue, null);
        private BuildingData _mock2 = new(BuildingType.Industrial, 1, CityResource.defaultValue, null);
        
        [Test]
        public void CreateTest()
        {
            var grid = new Grid(size: 10);
            var index1 = new GridIndex(0, 0);
            
            Assert.IsTrue(grid.TryPlace(index1, _mock1));
            Assert.IsFalse(grid.TryPlace(index1, _mock1));

            var index2 = new GridIndex(1, 1);
            Assert.IsTrue(grid.TryPlace(index2, _mock1));
        }

        [Test]
        public void ReadTest()
        {
            var grid = new Grid(size: 10);
            var index = new GridIndex(0, 0);
            
            grid.TryPlace(index, _mock1);

            Assert.IsTrue(grid.TryGet(index, out var getBuilding) && getBuilding.type == _mock1.type);
        }

        [Test]
        public void UpdateTest()
        {
            var grid = new Grid(size: 10);
            var index = new GridIndex(0, 0);
            
            grid.TryPlace(index, _mock1);
            grid.TryDelete(index, out var deletedBuilding);

            Assert.IsTrue(grid.TryPlace(index, _mock2));
            Assert.IsTrue(grid.TryGet(index, out var getBuilding) && getBuilding.type == _mock2.type);
        }

        [Test]
        public void DeleteTest()
        {
            var grid = new Grid(size: 10);
            var index = new GridIndex(0, 0);
            
            grid.TryPlace(index, _mock1);
            Assert.IsTrue(grid.TryDelete(index, out var deletedBuilding) && deletedBuilding.type == _mock1.type);
        }
            
    #endregion
        
    }
}