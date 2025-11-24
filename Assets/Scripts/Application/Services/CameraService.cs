namespace Application.Services.Camera
{
    using System;
    using ContractsInterfaces;
    using R3;
    using UnityEngine;
    using VContainer;
    using VContainer.Unity;

    public sealed class CameraService : IDisposable, ICameraService, ILateTickable
    {
        private readonly ICameraRepository _cameraRepository;
        private readonly Camera _camera;

        private IDisposable _subscription;
        private Vector3 _lookValue;
        
        [Inject]
        public CameraService(IInputService inputService, ICameraRepository cameraRepository)
        {
            _camera = Camera.main;
            _cameraRepository = cameraRepository;
            _subscription = inputService.onLookValue.Subscribe(CameraLook_Callback);
            Debug.Log("Test2");
        }

        private void CameraLook_Callback(Vector3 value)
        {
            _lookValue = new Vector3(value.x, 0f, value.y);
        }

        public void Dispose()
        {
            _subscription?.Dispose();
            _subscription = null;
        }

        public void LateTick()
        {
            var position = _camera.transform.position;
            _camera.transform.position = position + _lookValue * _cameraRepository.speed * Time.deltaTime;
        }
    }
}