using System;
using MiniGame.Scripts.CameraLogic;
using UnityEngine;
using Zenject;

namespace MiniGame.Scripts.Installers
{
    public class StartLevel : IInitializable, IDisposable
    {
        private readonly MiniGame _game;
        private readonly CameraProvider _cameraProvider;

        public StartLevel(MiniGame game, CameraProvider cameraProvider)
        {
            _game = game;
            _cameraProvider = cameraProvider;
        }

        public void Initialize()
        {
            _cameraProvider.SetMainCamera(Camera.main);
            _game.Start();
        }

        public void Dispose() => 
            _game.Stop();
    }
}