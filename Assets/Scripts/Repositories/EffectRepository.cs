namespace Repositories
{
    using System;
    using System.Collections.Generic;
    using ContractsInterfaces;
    using Domain.Common;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Softintermob/Configs/EffectConfig", fileName = "EffectConfig")]
    public sealed class EffectRepository : ScriptableObject, IEffectRepository
    {
        [SerializeField] private List<EffectRepositoryEntry> _entries = new();

        public IEnumerable<IEffectEntryRepository> entries => _entries;
    }
    
    [Serializable]
    public sealed class EffectRepositoryEntry : IEffectEntryRepository
    {
        [SerializeField] private EffectType _type;
        [SerializeField] private CityResource _income;
        [SerializeField] private float _incomeIntervalSec;

        public EffectType type => _type;
        public CityResource income => _income;
        public float incomeIntervalSec => _incomeIntervalSec;
    }
}