using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PureSpawner.Gameplay.Services;
using PureSpawner.Infrastructure;
using PureSpawner.Infrastructure.Pausing;
using PureSpawner.Infrastructure.StaticData;
using UnityEngine;

namespace PureSpawner.Gameplay.Enemies
{
    public class EnemySpawner : IPause
    {
        private readonly EnemyFactory _enemyFactory;
        private readonly IStaticDataService _staticData;
        private readonly ILevelService _levelService;
        private readonly ICoroutineRunner _runner;

        private Coroutine _spawning;
        private bool _isPaused;

        public EnemySpawner(EnemyFactory enemyFactory, IStaticDataService staticData, ILevelService levelService, ICoroutineRunner runner)
        {
            _enemyFactory = enemyFactory;
            _staticData = staticData;
            _levelService = levelService;
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
            var config = _staticData.GetEnemySpawnerConfig();
            var levelPoints = _levelService.GetEnemySpawnPoints().ToArray();

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

        private Enemy CreateRandomEnemy(IReadOnlyList<Transform> spawnPoints)
        {
            var enemy = _enemyFactory.Get(RandomEnemyType());
            enemy.MoveTo(RandomSpawnPoint(spawnPoints).position);
            return enemy;
        }

        private EnemyType RandomEnemyType()
        {
            var typeIndex = UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length);
            return (EnemyType) typeIndex;
        }

        private Transform RandomSpawnPoint(IReadOnlyList<Transform> points)
        {
            var randomIndex = UnityEngine.Random.Range(0, points.Count);
            return points[randomIndex];
        }
    }
}
