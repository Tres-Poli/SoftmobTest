namespace Application.Services.Camera
{
    using ContractsInterfaces;
    using UnityEngine;
    using VContainer;

    public sealed class PhysicsService : IPhysicsService
    {
        private readonly RaycastHit[] _hitBuffer;
        private readonly LayerMask _raycastMask;

        [Inject]
        public PhysicsService(IPhysicsRepository physicsRepository)
        {
            _hitBuffer = new RaycastHit[physicsRepository.hitBufferCapacity];
            _raycastMask = physicsRepository.raycastMask;
        }
        
        public GameObject RaycastFirst(Ray ray)
        {
            var hitCount = Physics.RaycastNonAlloc(ray, _hitBuffer);
            if (hitCount < 1)
            {
                return null;
            }

            return _hitBuffer[0].collider.gameObject;
        }
    }
}