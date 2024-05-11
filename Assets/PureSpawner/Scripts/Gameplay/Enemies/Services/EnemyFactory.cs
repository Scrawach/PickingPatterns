using PureSpawner.Gameplay.Enemies.Components;
using PureSpawner.Gameplay.Enemies.Configs;
using Zenject;

namespace PureSpawner.Gameplay.Enemies.Services
{
    public class EnemyFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly EnemyStaticDataService _staticDataService;

        public EnemyFactory(IInstantiator instantiator, EnemyStaticDataService staticDataService)
        {
            _instantiator = instantiator;
            _staticDataService = staticDataService;
        }

        public Enemy Get(EnemyType enemyType)
        {
            var config = _staticDataService.GetFor(enemyType);
            var instance = _instantiator.InstantiatePrefabForComponent<Enemy>(config.Prefab);
            instance.Initialize(config.Health, config.Speed);
            return instance;
        }
    }
}