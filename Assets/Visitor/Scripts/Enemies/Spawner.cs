using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Visitor.Scripts.Enemies
{
    public class Spawner: MonoBehaviour, IEnemyDeathNotifier, IEnemySpawnNotifier
    {
        [SerializeField] private float _spawnCooldown;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private EnemyFactory _enemyFactory;

        private List<Enemy> _spawnedEnemies = new List<Enemy>();
        
        private Coroutine _spawn;

        public event Action<Enemy> Died;
        public event Action<Enemy> Spawned;

        public bool IsWorking => _spawn != null;
        
        public void StartWork()
        {
            StopWork();

            _spawn = StartCoroutine(Spawn());
        }

        public void StopWork()
        {
            if (_spawn != null)
            {
                StopCoroutine(_spawn);
                _spawn = null;
            }
        }

        public void KillRandomEnemy()
        {
            if (_spawnedEnemies.Count == 0)
                return;

            _spawnedEnemies[UnityEngine.Random.Range(0, _spawnedEnemies.Count)].Kill();
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                var enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
                enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
                enemy.Died += OnEnemyDied;
                _spawnedEnemies.Add(enemy);
                yield return new WaitForSeconds(_spawnCooldown);
            }
        }

        private void OnEnemyDied(Enemy enemy)
        {
            Died?.Invoke(enemy);
            enemy.Died -= OnEnemyDied;
            _spawnedEnemies.Remove(enemy);
        }
    }
}