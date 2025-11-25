namespace Domain.Buildings
{
    using Common;
    using Effects;

    public struct BuildingData
    {
        private readonly BuildingType _type;
        private readonly int _level;
        private readonly CityResource _cost;
        private readonly IBuildingEffect _effect;

        public BuildingType type => _type;
        public int level => _level;
        public CityResource cost => _cost;
        public IBuildingEffect effect => _effect;

        public static BuildingData defaultValue => new BuildingData(BuildingType.Default, 0, CityResource.defaultValue, null);
        
        public BuildingData(BuildingType type, int level, CityResource cost, IBuildingEffect effect)
        {
            _type = type;
            _level = level;
            _cost = cost;
            _effect = effect;
        }
    }
}