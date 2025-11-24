namespace Domain.Tests.Grid
{
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

        [Test]
        public void CreateTest()
        {
            var grid = new Grid(size: 10);
            var index1 = new GridIndex(0, 0);

            var building1 = new MockBuilding();
            Assert.IsTrue(grid.TryPlace(index1, building1));

            var building2 = new MockBuilding();
            Assert.IsFalse(grid.TryPlace(index1, building2));

            var index2 = new GridIndex(1, 1);
            Assert.IsTrue(grid.TryPlace(index2, building2));
        }

        [Test]
        public void ReadTest()
        {
            var grid = new Grid(size: 10);
            var index = new GridIndex(0, 0);

            var building = new MockBuilding();
            grid.TryPlace(index, building);

            Assert.IsTrue(grid.TryGet(index, out var getBuilding) && getBuilding == building);
        }

        [Test]
        public void UpdateTest()
        {
            var grid = new Grid(size: 10);
            var index = new GridIndex(0, 0);
            
            var building1 = new MockBuilding();
            grid.TryPlace(index, building1);
            
            var building2 = new MockBuilding();
            grid.TryDelete(index, out var deletedBuilding);

            Assert.IsTrue(grid.TryPlace(index, building2));
            Assert.IsTrue(grid.TryGet(index, out var getBuilding) && getBuilding == building2);
        }

        [Test]
        public void DeleteTest()
        {
            var grid = new Grid(size: 10);
            var index = new GridIndex(0, 0);
            
            var building = new MockBuilding();
            grid.TryPlace(index, building);
            Assert.IsTrue(grid.TryDelete(index, out var deletedBuilding) && deletedBuilding == building);
        }
            
#endregion
    }
}