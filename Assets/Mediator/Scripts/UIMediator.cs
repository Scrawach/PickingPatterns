using UnityEngine;

namespace Mediator.Scripts
{
    public class UIMediator : MonoBehaviour
    {
        [SerializeField] private HealthMediator _healthMediator;
        [SerializeField] private AttackButton _attackButton;
        [SerializeField] private RestoreButton _restoreButton;

        private Health _health;
        
        public void Construct(Health health)
        {
            _health = health;
            
            _healthMediator.Construct(health);
            _attackButton.Construct(health);
            _restoreButton.Construct(health);

            _health.Changed += OnHealthChanged;
        }

        public void OnDestroy() => 
            _health.Changed -= OnHealthChanged;

        private void OnHealthChanged()
        {
            Debug.Log($"{_health.Current}");
            if (_health.Current <= 0)
            {
                _attackButton.Hide();
                _restoreButton.Show();
            }
            else
            {
                _attackButton.Show();
                _restoreButton.Hide();
            }
        }
    }
}