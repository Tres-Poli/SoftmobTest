namespace Application.Services.Camera
{
    using System;
    using System.Runtime.CompilerServices;
    using ContractsInterfaces;
    using Domain.Buildings;
    using Domain.Common;
    using UnityEngine;
    using Grid = Domain.Grid.Grid;
    using Object = UnityEngine.Object;

    public sealed class BuildingService : IBuildingService
    {
        private readonly IGridRepository _gridRepository;
        private readonly IBuildingRepository _buildingRepository;
        private readonly IEconomyService _economyService;
        private Grid _grid;

        private BuildingData[] _buildingsInfo;
        

        public BuildingService(IGridRepository gridRepository, IBuildingRepository buildingRepository, IEconomyService economyService)
        {
            _gridRepository = gridRepository;
            _buildingRepository = buildingRepository;
            _economyService = economyService;
        }
        
        public void Initialize()
        {
            BuildGrid();
            
            var buildingTypeCount = Enum.GetValues(typeof(BuildingType)).Length;
            _buildingsInfo = new BuildingData[buildingTypeCount];
            foreach (var entry in _buildingRepository.buildings)
            {
                _buildingsInfo[(int)entry.type % buildingTypeCount] = 
                    new BuildingData(entry.type, entry.level, entry.cost, null);
            }
        }
        
        public bool IsVacant(GridIndex index)
        {
            return _grid.IsVacant(index);
        }

        public BuildingData GetBuildingInfo(BuildingType type)
        {
            return _buildingsInfo[(int)type % _buildingsInfo.Length];
        }

        public void CreateBuilding(BuildingType type, GridIndex index)
        {
            var info = GetBuildingInfo(type);
            if (_grid.TryPlace(index, info))
            {
                
            }
        }

        public void DeleteBuilding(BuildingType type, GridIndex index)
        {
            
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void BuildGrid()
        {
            var offset = _gridRepository.tileSize * _gridRepository.gridSize / 2f - _gridRepository.tileSize / 2f + _gridRepository.gridSize / 2f * _gridRepository.margin;
            var topLeftPosition = _gridRepository.tileContainer.position - new Vector3(offset, 0f, offset);
            for (int i = 0; i < _gridRepository.gridSize; i++)
            {
                for (int j = 0; j < _gridRepository.gridSize; j++)
                {
                    var positionX = topLeftPosition.x + i * _gridRepository.tileSize + i * _gridRepository.margin;
                    var positionZ = topLeftPosition.z + j * _gridRepository.tileSize + j * _gridRepository.margin;
                    var instance = Object.Instantiate(_gridRepository.tilePrefab, new Vector3(positionX, 0.01f, positionZ), 
                        Quaternion.Euler(90f, 0f, 0f), _gridRepository.tileContainer);
                    instance.transform.localScale = new Vector3(_gridRepository.tileSize, _gridRepository.tileSize, 1f);
                    
                    
                }
            }
        }
    }
}