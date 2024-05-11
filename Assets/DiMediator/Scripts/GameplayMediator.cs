using System;
using UnityEngine;
using Zenject;

namespace DiMediator
{
    public class GameplayMediator : IInitializable, IDisposable
    {
        private readonly DefeatPanel _defeatPanel;
        private readonly Level _level;

        public GameplayMediator(DefeatPanel defeatPanel, Level level)
        {
            _defeatPanel = defeatPanel;
            _level = level;
        }

        public void Initialize()
        {
            _level.Defeat += OnLevelDefeat;
            _defeatPanel.RestartPressed += OnRestartPressed;
        }
        
        public void Dispose()
        {
            _level.Defeat -= OnLevelDefeat;
            _defeatPanel.RestartPressed -= OnRestartPressed;
        }

        private void OnRestartPressed()
        {
            Debug.Log($"RESTART");
            _defeatPanel.Hide();
            _level.Restart();
        }
        
        private void OnLevelDefeat()
        {
            Debug.Log("ON DEFEAT");
            _defeatPanel.Show();
        }
    }
}