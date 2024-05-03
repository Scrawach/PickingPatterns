using UnityEngine;

namespace Visitor.Scripts.Enemies
{
    public class VisitorBootstrap : MonoBehaviour
    {
        [SerializeField] private Spawner _enemySpawner;
        [SerializeField] private int _maxSpawnerWeight;

        private Score _score;
        private SpawnerWeight _weight;

        private void Awake()
        {
            _score = new Score(_enemySpawner);
            _weight = new SpawnerWeight(_enemySpawner);
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
                _enemySpawner.KillRandomEnemy();
            
            SpawnControl();
        }

        private void SpawnControl()
        {
            if (_weight.Value < _maxSpawnerWeight && !_enemySpawner.IsWorking)
                _enemySpawner.StartWork();
            else if (_weight.Value >= _maxSpawnerWeight && _enemySpawner.IsWorking)
                _enemySpawner.StopWork();
        }
    }
}