namespace Application.Services.Camera
{
    using Domain;
    using Domain.Common;

    public sealed class EconomyService
    {
        private PlayerResources _playerResources;

        public void Initialize()
        {
            // TODO: past resource value from save/load
            _playerResources = new PlayerResources(0, 0, 0);
        }

        public bool CanAfford(CityResource value)
        {
            return _playerResources.CanAfford(value);
        }
    }
}