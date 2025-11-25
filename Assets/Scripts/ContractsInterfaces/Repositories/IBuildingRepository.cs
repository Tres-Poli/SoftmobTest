namespace ContractsInterfaces
{
    using System.Collections.Generic;

    public interface IBuildingRepository
    {
        public IEnumerable<IBuildingRepositoryEntry> buildings { get; }
    }
}