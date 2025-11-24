namespace Application
{
    using ContractsInterfaces;
    using Infrastructure.Common;
    using Services.Camera;
    using UnityEngine;
    using VContainer;
    using VContainer.Unity;

    [CreateAssetMenu(menuName = "Softintermob/Installers/ApplicationInstaller", fileName = "ApplicationInstaller")]
    public class ApplicationInstaller : DependencyInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<CameraService>().As<ICameraService>();
            builder.Register<InputRouterService>(Lifetime.Singleton);
        }
    }
}