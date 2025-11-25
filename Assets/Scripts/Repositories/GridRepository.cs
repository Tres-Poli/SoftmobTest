namespace Repositories
{
    using ContractsInterfaces;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Softintermob/Configs/GridConfig", fileName = "GridConfig")]
    public sealed class GridRepository : ScriptableObject, IGridRepository
    {
        [SerializeField] private int _gridSize;
        [SerializeField] private GameObject _tilePrefab;
        [SerializeField] private Transform _tileContainer;
        [SerializeField] private float _tileSize;
        [SerializeField] private float _margin;
        
        public int gridSize => _gridSize;
        public GameObject tilePrefab => _tilePrefab;
        public Transform tileContainer => _tileContainer;
        public float tileSize => _tileSize;
        public float margin => _margin;
    }
}