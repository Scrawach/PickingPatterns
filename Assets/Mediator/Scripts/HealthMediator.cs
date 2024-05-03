using System;
using UnityEngine;

namespace Mediator.Scripts
{
    public class HealthMediator : MonoBehaviour
    {
        [SerializeField] private HealthBar _healthBar;

        private Health _health;
        
        public void Construct(Health health)
        {
            _health = health;
            _health.Changed += OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            _healthBar.Fill(_health.Ratio);
        }

        private void OnDestroy() => 
            _health.Changed -= OnHealthChanged;
    }
}