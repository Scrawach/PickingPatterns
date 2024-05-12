using System;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGame.Scripts.UI.View
{
    public class VictoryPanel : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;

        public event Action RestartClicked;
        public event Action MainMenuClicked;
        
        private void OnEnable()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
            _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
        }

        private void OnMainMenuButtonClicked() => 
            MainMenuClicked?.Invoke();

        private void OnRestartButtonClicked() => 
            RestartClicked?.Invoke();

        public void Hide() => gameObject.SetActive(false);
        
        public void Show() => gameObject.SetActive(true);
    }
}