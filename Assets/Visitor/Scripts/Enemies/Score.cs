using System;
using UnityEngine;

namespace Visitor.Scripts.Enemies
{
    public class Score : IDisposable
    {
        public int Value => _enemyVisitor.Score;

        private readonly IEnemyDeathNotifier _enemyDeathNotifier;
        private readonly EnemyVisitor _enemyVisitor;

        public Score(IEnemyDeathNotifier enemyDeathNotifier)
        {
            _enemyDeathNotifier = enemyDeathNotifier;
            _enemyDeathNotifier.Died += OnEnemyKilled;

            _enemyVisitor = new EnemyVisitor();
        }

        private void OnEnemyKilled(Enemy enemy)
        {
            enemy.Accept(_enemyVisitor);
            Debug.Log("Score: " + Value);
        }

        public void Dispose()
        {
            _enemyDeathNotifier.Died -= OnEnemyKilled;
        }

        private class EnemyVisitor : IEnemyVisitor
        {
            public int Score { get; private set; }

            public void Visit(Elf elf) => Score += 10;

            public void Visit(Human human) => Score += 5;
        }
    }
}