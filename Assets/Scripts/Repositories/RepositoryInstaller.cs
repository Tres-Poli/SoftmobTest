namespace Repositories
{
    using ContractsInterfaces;
    using Infrastructure.Common;
    using UnityEngine;
    using VContainer;
    
    [CreateAssetMenu(menuName = "Softintermob/Installers/RepositoryInstaller")]
    public class RepositoryInstaller : DependencyInstaller
    {
        [SerializeField] private CameraRepository _cameraRepository;
        [SerializeField] private PhysicsRepository _physicsRepository;
        [SerializeField] private BuildingsRepository _buildingsRepository;
        [SerializeField] private GridRepository _gridRepository;
        [SerializeField] private EffectRepository _effectRepository;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(Instantiate(_cameraRepository)).As<ICameraRepository>();
            builder.RegisterInstance(Instantiate(_physicsRepository)).As<IPhysicsRepository>();
            builder.RegisterInstance(Instantiate(_buildingsRepository)).As<IBuildingRepository>();
            builder.RegisterInstance(Instantiate(_gridRepository)).As<IGridRepository>();
            builder.RegisterInstance(Instantiate(_effectRepository)).As<IEffectRepository>();
        }
    }
}