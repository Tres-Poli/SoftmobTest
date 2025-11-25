namespace Repositories
{
    using System;
    using System.Collections.Generic;
    using ContractsInterfaces;
    using Domain.Common;
    using UnityEngine;

    [CreateAssetMenu(menuName = "SoftIntermob/Config/BuildingsConfig", fileName = "buildingsConfig")]
    public sealed class BuildingsRepository : ScriptableObject, IBuildingRepository
    {
        [SerializeField] private List<BuildingRepositoryEntry> entries = new();
        
        public IEnumerable<IBuildingRepositoryEntry> buildings => entries;
    }

    [Serializable]
    public sealed class BuildingRepositoryEntry : IBuildingRepositoryEntry
    {
        public BuildingType type { get; set; }
        public int level { get; set; }
        public CityResource cost { get; set; }
        public CityResource income { get; set; }
        public float tickIntervalSec { get; set; }
    }
}