namespace Domain.Grid
{
    using System.Runtime.CompilerServices;
    using Buildings;

    public sealed class Grid
    {
        private readonly int _size;
        private readonly IBuilding[][] _buildingsMatrix;

        public Grid(int size)
        {
            _size = size;
            _buildingsMatrix = new IBuilding[size][];
            for (int i = 0; i < size; i++)
            {
                _buildingsMatrix[i] = new IBuilding[size];
            }
        }

        public bool TryPlace(GridIndex index, IBuilding building)
        {
            if (!IsValidIndex(index))
            {
                return false;
            }
            
            if (!IsVacant(index))
            {
                return false;
            }

            _buildingsMatrix[index.x][index.y] = building;
            
            return true;
        }

        public bool TryMove(GridIndex from, GridIndex to, out IBuilding building)
        {
            building = null;
            if (!(IsValidIndex(from) && IsValidIndex(to)))
            {
                return false;
            }

            if (IsVacant(from) || !IsVacant(to))
            {
                return false;
            }

            building = _buildingsMatrix[from.x][from.y];
            _buildingsMatrix[to.x][to.y] = building;
            _buildingsMatrix[from.x][from.y] = null;
            
            return true;
        }

        public bool TryDelete(GridIndex index, out IBuilding building)
        {
            building = null;
            if (!IsValidIndex(index))
            {
                return false;
            }

            if (IsVacant(index))
            {
                return false;
            }

            building = _buildingsMatrix[index.x][index.y];
            _buildingsMatrix[index.x][index.y] = null;
            
            return true;
        }

        public bool TryGet(GridIndex index, out IBuilding building)
        {
            building = null;
            if (!IsValidIndex(index))
            {
                return false;
            }

            if (IsVacant(index))
            {
                return false;
            }
            
            building = _buildingsMatrix[index.x][index.y];
            
            return true;
        }

        public bool IsVacant(GridIndex index)
        {
            var building = _buildingsMatrix[index.x][index.y];
            return building == null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsValidIndex(GridIndex index)
        {
            return index.x >= 0 && index.x < _size && index.y >= 0 && index.y < _size;
        }
    }
}