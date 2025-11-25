namespace ContractsInterfaces
{
    using UnityEngine;

    public interface ICameraService
    {
        public Ray ScreenPointToRay(Vector2 value);
        public void SetCameraMoveDirection(Vector3 value);
    }
}