namespace ContractsInterfaces
{
    using UnityEngine;

    public interface IPhysicsService
    {
        public GameObject RaycastFirst(Ray ray);
    }
}