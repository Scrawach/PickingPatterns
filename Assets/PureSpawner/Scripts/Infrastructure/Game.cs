using PureSpawner.Gameplay.Enemies.Configs;
using PureSpawner.Gameplay.Enemies.Services;

namespace PureSpawner.Infrastructure
{
    public class Game
    {
        private readonly EnemyStaticDataService _enemyStaticData;
        private readonly EnemySpawnerStaticDataService _enemySpawnerStaticData;
        private readonly EnemySpawner _enemySpawner;

        public Game(EnemyStaticDataService enemyStaticData, EnemySpawnerStaticDataService enemySpawnerStaticData, EnemySpawner enemySpawner)
        {
            _enemyStaticData = enemyStaticData;
            _enemySpawnerStaticData = enemySpawnerStaticData;
            _enemySpawner = enemySpawner;
        }

        public void Start()
        {
            LoadStaticData();
            
            _enemySpawner.StartWork();
        }

        private void LoadStaticData()
        {
            _enemyStaticData.Load();
            _enemySpawnerStaticData.Load();
        }
    }
}