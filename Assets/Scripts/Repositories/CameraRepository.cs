namespace Repositories
{
    using ContractsInterfaces;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Softintermob/Configs/Camera", fileName = "CameraConfig")]
    public class CameraRepository : ScriptableObject, ICameraRepository
    {
        [field: SerializeField] public int speed { get; set; }
    }
}