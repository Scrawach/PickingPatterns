using UnityEngine;
using UnityEngine.UI;

namespace Mediator.Scripts
{
    public class AttackButton : MonoBehaviour
    {
        [SerializeField] private Button _attackButton;
        [SerializeField] private int _damage;

        private Health _health;

        public void Construct(Health health) => 
            _health = health;

        public void Show() => 
            _attackButton.gameObject.SetActive(true);

        public void Hide() =>
            _attackButton.gameObject.SetActive(false);
        
        private void OnEnable() => 
            _attackButton.onClick.AddListener(OnProcessAttack);

        private void OnDisable() => 
            _attackButton.onClick.RemoveListener(OnProcessAttack);

        private void OnProcessAttack() => 
            _health.TakeDamage(_damage);
    }
}