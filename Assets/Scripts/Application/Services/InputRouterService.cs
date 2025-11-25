namespace Application.Services.Camera
{
    using System;
    using ContractsInterfaces;
    using Domain.MessageDTO;
    using MessagePipe;
    using R3;
    using UnityEngine;
    using VContainer;

    public class InputRouterService : IInputRouterService, IDisposable
    {
        private readonly ICameraService _cameraService;
        private readonly IPhysicsService _physicsService;
        private readonly IPublisher<TileClickedMessage> _tileClickedPublisher;
        private readonly IPublisher<BuildingClickedMessage> _buildingClickedPublisher;

        private CompositeDisposable _disposables;

        [Inject]
        public InputRouterService(ICameraService cameraService, IPhysicsService physicsService, IInputService inputService,
            IPublisher<TileClickedMessage> tileClickedPublisher, IPublisher<BuildingClickedMessage> buildingClickedPublisher)
        {
            _cameraService = cameraService;
            _physicsService = physicsService;
            _tileClickedPublisher = tileClickedPublisher;
            _buildingClickedPublisher = buildingClickedPublisher;

            _disposables = new CompositeDisposable();
            _disposables.Add(inputService.onLookValue.Subscribe(OnLookValue_Callback));
            _disposables.Add(inputService.onPointerClick.Subscribe(OnPointerClickValue_Callback));
            _disposables.Add(inputService.onPointer.Subscribe());
        }

        private void OnLookValue_Callback(Vector3 value)
        {
            var invertedValue = new Vector3(value.x, 0f, value.y);
            _cameraService.SetCameraMoveDirection(invertedValue);
        }

        private void OnPointerClickValue_Callback(Vector2 value)
        {
            var ray = _cameraService.ScreenPointToRay(value);
            var go = _physicsService.RaycastFirst(ray);
        }

        private void OnPointerValue_Callback(Vector2 value)
        {
            var ray = _cameraService.ScreenPointToRay(value);
        }

        public void Dispose()
        {
            _disposables?.Dispose();
            _disposables = null;
        }
    }
}