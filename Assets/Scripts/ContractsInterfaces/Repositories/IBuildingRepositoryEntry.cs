namespace ContractsInterfaces
{
    using Domain.Common;

    public interface IBuildingRepositoryEntry
    {
        public BuildingType type { get; }
        public int level { get; }
        public CityResource cost { get;  }
        public CityResource income { get; }
        public float tickIntervalSec { get;  }
    }
}