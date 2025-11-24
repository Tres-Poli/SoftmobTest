namespace Infrastructure
{
    using Common;
    using ContractsInterfaces;
    using Input;
    using UnityEngine;
    using VContainer;
    using VContainer.Unity;

    [CreateAssetMenu(menuName = "Softintermob/Installers/InfrastructureInstaller")]
    public sealed class InfrastructionInstaller : DependencyInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            //builder.RegisterInstance(new InputService()).As<IInputService>();
            builder.RegisterEntryPoint<InputService>().As<IInputService>();
            builder.RegisterBuildCallback(c => c.Resolve<IInputService>().Enable());
        }
    }
}