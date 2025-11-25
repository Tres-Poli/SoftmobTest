namespace ContractsInterfaces
{
    using System.Collections.Generic;

    public interface IEffectRepository
    {
        public IEnumerable<IEffectEntryRepository> entries { get; }
    }
}