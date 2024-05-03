using System;
using UnityEngine;

namespace Visitor.Scripts.Enemies
{
    public class SpawnerWeight : IDisposable
    {
        public int Value => _spawnEnemyVisitor.Weight;

        private readonly IEnemySpawnNotifier _enemySpawnNotifier;
        private readonly EnemyVisitor _spawnEnemyVisitor;

        public SpawnerWeight(IEnemySpawnNotifier enemySpawnNotifier)
        {
            _enemySpawnNotifier = enemySpawnNotifier;
            _enemySpawnNotifier.Spawned += OnEnemySpawned;
            _spawnEnemyVisitor = new EnemyVisitor();
        }

        private void OnEnemySpawned(Enemy enemy)
        {
            enemy.Accept(_spawnEnemyVisitor);
            Debug.Log("Spawner Weight: " + Value);
        }
        
        public void Dispose() => 
            _enemySpawnNotifier.Spawned -= OnEnemySpawned;

        private class EnemyVisitor : IEnemyVisitor
        {
            public int Weight { get; private set; }
            
            public void Visit(Elf elf) => Weight += 1;

            public void Visit(Human human) => Weight += 2;
        }
    }
}