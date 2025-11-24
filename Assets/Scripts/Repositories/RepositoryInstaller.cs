namespace Repositories
{
    using ContractsInterfaces;
    using Infrastructure.Common;
    using UnityEngine;
    using VContainer;
    
    [CreateAssetMenu(menuName = "Softintermob/Installers/RepositoryInstaller")]
    public class RepositoryInstaller : DependencyInstaller
    {
        [SerializeReference] private CameraRepository _cameraRepository;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(Instantiate(_cameraRepository)).As<ICameraRepository>();
        }
    }
}