namespace Domain.Grid
{
    using System.Runtime.CompilerServices;
    using Buildings;
    using Common;

    public struct Grid
    {
        private readonly int _size;
        private readonly BuildingData[][] _buildingsMatrix;

        public Grid(int size)
        {
            _size = size;
            _buildingsMatrix = new BuildingData[size][];
            for (int i = 0; i < size; i++)
            {
                _buildingsMatrix[i] = new BuildingData[size];
            }
        }

        public bool TryPlace(GridIndex index, BuildingData buildingData)
        {
            if (!IsValidIndex(index))
            {
                return false;
            }
            
            if (!IsVacant(index))
            {
                return false;
            }

            _buildingsMatrix[index.x][index.y] = buildingData;
            
            return true;
        }

        public bool TryMove(GridIndex from, GridIndex to, out BuildingData buildingData)
        {
            buildingData = BuildingData.defaultValue;
            if (!(IsValidIndex(from) && IsValidIndex(to)))
            {
                return false;
            }

            if (IsVacant(from) || !IsVacant(to))
            {
                return false;
            }

            buildingData = _buildingsMatrix[from.x][from.y];
            _buildingsMatrix[to.x][to.y] = buildingData;
            _buildingsMatrix[from.x][from.y] = BuildingData.defaultValue;
            
            return true;
        }

        public bool TryDelete(GridIndex index, out BuildingData buildingData)
        {
            buildingData = BuildingData.defaultValue;
            if (!IsValidIndex(index))
            {
                return false;
            }

            if (IsVacant(index))
            {
                return false;
            }

            buildingData = _buildingsMatrix[index.x][index.y];
            _buildingsMatrix[index.x][index.y] = BuildingData.defaultValue;
            
            return true;
        }

        public bool TryGet(GridIndex index, out BuildingData buildingData)
        {
            buildingData = BuildingData.defaultValue;
            if (!IsValidIndex(index))
            {
                return false;
            }

            if (IsVacant(index))
            {
                return false;
            }
            
            buildingData = _buildingsMatrix[index.x][index.y];
            
            return true;
        }

        public bool IsVacant(GridIndex index)
        {
            var building = _buildingsMatrix[index.x][index.y];
            return building.type == BuildingType.Default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsValidIndex(GridIndex index)
        {
            return index.x >= 0 && index.x < _size && index.y >= 0 && index.y < _size;
        }
    }
}