using UnityEngine;
using UnityEngine.UI;

namespace Mediator.Scripts
{
    public class RestoreButton : MonoBehaviour
    {
        [SerializeField] private Button _restoreButton;
        
        private Health _health;

        public void Construct(Health health) => 
            _health = health;

        public void Show() => 
            _restoreButton.gameObject.SetActive(true);

        public void Hide() =>
            _restoreButton.gameObject.SetActive(false);

        private void OnEnable() => 
            _restoreButton.onClick.AddListener(OnFullRestore);

        private void OnDisable() => 
            _restoreButton.onClick.RemoveListener(OnFullRestore);

        private void OnFullRestore() =>
            _health.FullRestore();
    }
}