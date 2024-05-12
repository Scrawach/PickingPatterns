using System;
using MiniGame.Scripts.CameraLogic;
using MiniGame.Scripts.SceneManagement;
using MiniGame.Scripts.UI;
using UnityEngine;
using Zenject;

namespace MiniGame.Scripts.Installers
{
    public class GameLoop : IInitializable, IDisposable
    {
        private readonly MiniGame _game;
        private readonly CameraProvider _camera;
        private readonly GameplayUI _gameplayUI;

        public GameLoop(MiniGame game, CameraProvider camera, GameplayUI gameplayUI)
        {
            _game = game;
            _camera = camera;
            _gameplayUI = gameplayUI;
        }

        public void Initialize()
        {
            _camera.SetMainCamera(Camera.main);
            
            _game.Start();
            _game.Completed += OnGameCompleted;
        }

        public void Dispose()
        {
            _game.Completed -= OnGameCompleted;
            _game.Stop();
        }

        private void OnGameCompleted()
        {
            _gameplayUI.ShowVictoryWindow();
        }
    }
}