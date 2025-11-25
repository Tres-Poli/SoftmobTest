namespace ContractsInterfaces
{
    using UnityEngine;

    public interface IPhysicsRepository
    {
        public int hitBufferCapacity { get; }
        public LayerMask raycastMask { get; }
    }
}