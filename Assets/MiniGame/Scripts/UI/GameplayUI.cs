using System;
using MiniGame.Scripts.Gameplay.Conditions;
using MiniGame.Scripts.SceneManagement;
using MiniGame.Scripts.UI.View;
using Zenject;

namespace MiniGame.Scripts.UI
{
    public class GameplayUI : IInitializable, IDisposable
    {
        private readonly SceneLoaderMediator _sceneLoader;
        private readonly UIFactory _uiFactory;
        private readonly WinConditionProvider _winCondition;

        private VictoryPanel _victoryPanel;
        
        public GameplayUI(SceneLoaderMediator sceneLoader, UIFactory uiFactory, WinConditionProvider winCondition)
        {
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _winCondition = winCondition;
        }

        public void Initialize()
        {
            _victoryPanel = _uiFactory.CreateVictoryPanel();
            _victoryPanel.RestartClicked += OnRestartClicked;
            _victoryPanel.MainMenuClicked += OnMainMenuClicked;
            _victoryPanel.Hide();
        }

        public void Dispose()
        {
            _victoryPanel.RestartClicked -= OnRestartClicked;
            _victoryPanel.MainMenuClicked -= OnMainMenuClicked;
        }

        public void ShowVictoryWindow() => 
            _victoryPanel.Show();

        private void OnMainMenuClicked() => 
            _sceneLoader.GoToMainMenu();

        private void OnRestartClicked() => 
            _sceneLoader.GoToGameplay(_winCondition.Type);
    }
}