using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PureSpawner.Gameplay.Enemies.Components;
using PureSpawner.Gameplay.Enemies.Configs;
using PureSpawner.Infrastructure;
using PureSpawner.Infrastructure.Pausing;
using UnityEngine;

namespace PureSpawner.Gameplay.Enemies.Services
{
    public class EnemySpawner : IPause
    {
        private readonly EnemyFactory _enemyFactory;
        private readonly EnemySpawnerStaticDataService _enemySpawnerStaticData;
        private readonly ICoroutineRunner _runner;

        private Coroutine _spawning;
        private bool _isPaused;

        public EnemySpawner(EnemyFactory enemyFactory, EnemySpawnerStaticDataService enemySpawnerStaticData, ICoroutineRunner runner)
        {
            _enemyFactory = enemyFactory;
            _enemySpawnerStaticData = enemySpawnerStaticData;
            _runner = runner;
        }

        public void StartWork()
        {
            StopWork();
            _spawning = _runner.StartCoroutine(Spawning());
        }

        public void StopWork()
        {
            if (_spawning == null) 
                return;
            
            _runner.StopCoroutine(_spawning);
            _spawning = null;
        }
        
        public void SetPause(bool isPaused) => 
            _isPaused = isPaused;

        private IEnumerator Spawning()
        {
            var time = 0f;
            var config = _enemySpawnerStaticData.GetEnemySpawnerConfig();
            var levelPoints = _enemySpawnerStaticData.GetEnemySpawnPoints().ToArray();

            while (true)
            {
                while(time < config.Cooldown)
                {
                    if(_isPaused == false)
                        time += Time.deltaTime;

                    yield return null;  
                }
                
                CreateRandomEnemy(levelPoints);
                time = 0;
            }
        }

        private Enemy CreateRandomEnemy(IReadOnlyList<Vector3> spawnPoints)
        {
            var enemy = _enemyFactory.Get(RandomEnemyType());
            enemy.MoveTo(RandomSpawnPoint(spawnPoints));
            return enemy;
        }

        private static EnemyType RandomEnemyType()
        {
            var typeIndex = UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length);
            return (EnemyType) typeIndex;
        }

        private static Vector3 RandomSpawnPoint(IReadOnlyList<Vector3> points)
        {
            var randomIndex = UnityEngine.Random.Range(0, points.Count);
            return points[randomIndex];
        }
    }
}
