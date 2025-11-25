namespace ContractsInterfaces
{
    using Domain.Buildings;
    using Domain.Common;

    public interface IBuildingService
    {
        public bool IsVacant(GridIndex index);
        public BuildingData GetBuildingInfo(BuildingType type);
    }
}