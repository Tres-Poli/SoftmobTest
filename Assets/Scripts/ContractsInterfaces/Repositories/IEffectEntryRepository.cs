namespace ContractsInterfaces
{
    using Domain.Common;

    public interface IEffectEntryRepository
    {
        public EffectType type { get; }
        public CityResource income { get; }
        public float  incomeIntervalSec { get; }
    }
}