namespace Application.Services.Camera
{
    using ContractsInterfaces;
    using VContainer;

    public class InputRouterService
    {
        private readonly ICameraService _cameraService;
        
        [Inject]
        public InputRouterService(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }
    }
}