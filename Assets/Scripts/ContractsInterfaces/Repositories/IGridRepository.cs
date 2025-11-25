namespace ContractsInterfaces
{
    using UnityEngine;

    public interface IGridRepository
    {
        public int gridSize { get; }
        public GameObject tilePrefab { get; }
        public Transform tileContainer { get; }
        public float tileSize { get; }
        public float margin { get; }
    }
}