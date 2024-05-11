using PureSpawner.Gameplay.Enemies;
using UnityEngine;
using Zenject;

namespace PureSpawner.Gameplay.Player
{
    public class Player : MonoBehaviour, IEnemyTarget
    {
        private int _maxHealth;
        private int _health;

        public Vector3 Position => transform.position;

        [Inject]
        private void Construct(PlayerStatsConfig statsConfig)
        {
            _health = _maxHealth = statsConfig.MaxHealth;
            Debug.Log($"ÕÏ: {_health}");
        }

        public void TakeDamage(int damage)
        {
        }
    }
}