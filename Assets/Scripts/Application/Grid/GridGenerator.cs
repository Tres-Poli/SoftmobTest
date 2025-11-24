namespace Application.Grid
{
    using UnityEditor;
    using UnityEngine;

    public sealed class GridGenerator : MonoBehaviour
    {
        [SerializeField] private int _gridSize;
        [SerializeField] private GameObject _tilePrefab;
        [SerializeField] private Transform _tileContainer;
        [SerializeField] private float _tileSize;
        [SerializeField] private float _margin;
        
        [ContextMenu("Generate Grid")]
        public void GenerateGrid()
        {
            var offset = _tileSize * _gridSize / 2f - _tileSize / 2f + _gridSize / 2f * _margin;
            var topLeftPosition = transform.position - new Vector3(offset, 0f, offset);
            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    var positionX = topLeftPosition.x + i * _tileSize + i * _margin;
                    var positionZ = topLeftPosition.z + j * _tileSize + j * _margin;
                    var instance = Instantiate(_tilePrefab, new Vector3(positionX, 0.01f, positionZ), Quaternion.Euler(90f, 0f, 0f), _tileContainer);
                    instance.transform.localScale = new Vector3(_tileSize, _tileSize, 1f);
                }
            }
            
            AssetDatabase.SaveAssets();
        }

        [ContextMenu("Clear tiles")]
        public void ClearTiles()
        {
            while (_tileContainer.childCount > 0)
            {
                DestroyImmediate(_tileContainer.GetChild(0).gameObject);
            }
        }
    }
}