using PureSpawner.Gameplay;
using PureSpawner.Gameplay.Enemies.Configs;
using PureSpawner.Gameplay.Enemies.Services;
using PureSpawner.Infrastructure.AssetManagement;
using PureSpawner.Infrastructure.Pausing;
using UnityEngine;
using Zenject;

namespace PureSpawner.Infrastructure.Installers
{
    public class GameInstaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField] private TargetPoint _targetPoint;
        
        public override void InstallBindings()
        {
            BindInfrastructureServices();
            BindDataServices();
            BindGameplayServices();
        }
        
        private void BindInfrastructureServices()
        {
            Container.Bind<IAssets>().To<ResourceAssets>().AsSingle();
            Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
            Container.Bind<PauseHandler>().AsSingle();
            Container.Bind<Game>().AsSingle();
            
            Container.Bind<IInitializable>().To<GameBootstrapper>().AsSingle().NonLazy();
        }
        
        private void BindDataServices()
        {
            Container.Bind<EnemyStaticDataService>().AsSingle();
            Container.Bind<EnemySpawnerStaticDataService>().AsSingle();
        }
        
        private void BindGameplayServices()
        {
            Container.Bind<EnemyFactory>().AsSingle();
            Container.Bind<EnemySpawner>().AsSingle();
            Container.Bind<IEnemyTarget>().FromInstance(_targetPoint);
        }
    }
}