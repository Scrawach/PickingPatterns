using System;
using MiniGame.Scripts.Gameplay.Conditions;
using MiniGame.Scripts.SceneManagement;
using MiniGame.Scripts.UI.View;
using Zenject;

namespace MiniGame.Scripts.UI
{
    public class MainMenuUI : IInitializable, IDisposable
    {
        private readonly SceneLoaderMediator _sceneLoader;
        private readonly UIFactory _factory;

        private MainMenuPanel _root;
        
        public MainMenuUI(SceneLoaderMediator sceneLoader, UIFactory factory)
        {
            _sceneLoader = sceneLoader;
            _factory = factory;
        }

        public void Initialize()
        {
            _root = _factory.CreateMainMenuPanel();
            _root.ConditionSelected += OnConditionSelected;
        }
        
        public void Dispose() => 
            _root.ConditionSelected -= OnConditionSelected;

        private void OnConditionSelected(ConditionType type) => 
            _sceneLoader.GoToGameplay(type);
    }
}