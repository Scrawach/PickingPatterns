using System;
using System.Collections.Generic;
using PureSpawner.Infrastructure.AssetManagement;
using UnityEngine;

namespace PureSpawner.Gameplay.Enemies.Configs
{
    public class EnemySpawnerStaticDataService
    {
        private const string ConfigPath = "Configs/Enemy Spawner Config";
        
        private readonly IAssets _assets;

        private EnemySpawnerConfig _config;

        public EnemySpawnerStaticDataService(IAssets assets) => 
            _assets = assets;

        public void Load() => 
            _config = _assets.Load<EnemySpawnerConfig>(ConfigPath);

        public EnemySpawnerConfig GetEnemySpawnerConfig() => 
            _config;

        public IEnumerable<Vector3> GetEnemySpawnPoints() => 
            _config.SpawnPoints;
    }
}