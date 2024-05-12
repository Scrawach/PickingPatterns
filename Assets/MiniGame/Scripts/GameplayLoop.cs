using System;
using MiniGame.Scripts.CameraLogic;
using MiniGame.Scripts.UI;
using UnityEngine;
using Zenject;

namespace MiniGame.Scripts
{
    public class GameplayLoop : IInitializable, IDisposable
    {
        private readonly MiniGame _game;
        private readonly CameraProvider _camera;
        private readonly GameplayUI _gameplayUI;

        public GameplayLoop(MiniGame game, CameraProvider camera, GameplayUI gameplayUI)
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