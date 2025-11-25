namespace Repositories
{
    using ContractsInterfaces;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Softintermob/Configs/PhysicsConfig")]
    public sealed class PhysicsRepository : ScriptableObject, IPhysicsRepository
    {
        [SerializeField] private int _hitBufferCapacity = 16;
        [SerializeField] private LayerMask _raycastMask;

        public int hitBufferCapacity => _hitBufferCapacity;
        public LayerMask raycastMask => _raycastMask;
    }
}