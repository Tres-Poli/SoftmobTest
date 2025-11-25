namespace Application.Services.Camera
{
    using ContractsInterfaces;
    using UnityEngine;
    using VContainer;
    using VContainer.Unity;

    public sealed class CameraService : ICameraService, ILateTickable
    {
        private readonly ICameraRepository _cameraRepository;
        private readonly Camera _camera;
        
        private Vector3 _lookValue;
        
        [Inject]
        public CameraService(ICameraRepository cameraRepository)
        {
            _camera = Camera.main;
            _cameraRepository = cameraRepository;
        }

        public void SetCameraMoveDirection(Vector3 value)
        {
            _lookValue = value;
        }

        public Ray ScreenPointToRay(Vector2 value)
        {
            return _camera.ScreenPointToRay(value);
        }

        public void LateTick()
        {
            var position = _camera.transform.position;
            _camera.transform.position = position + _lookValue * _cameraRepository.speed * Time.deltaTime;
        }
    }
}