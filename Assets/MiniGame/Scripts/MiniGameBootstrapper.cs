using MiniGame.Scripts.AssetManagement;
using MiniGame.Scripts.Data;
using MiniGame.Scripts.Gameplay.Balls;
using MiniGame.Scripts.Gameplay.Balls.View;
using MiniGame.Scripts.Gameplay.Generators;
using UnityEngine;

namespace MiniGame.Scripts
{
    public class MiniGameBootstrapper : MonoBehaviour
    {
        [SerializeField] private Transform _center;
        [SerializeField] private int _amountOfBalls;
        [SerializeField] private float _radius;

        private void Start()
        {
            var assets = new ResourcesAssets();
            var gameSettings = new SettingsAsset(assets);
            var staticData = new StaticData(gameSettings);
            var ballRegistry = new BallRegistry();
            var ballAsset = new BallAsset(assets);
            var ballViewFactory = new BallViewFactory(ballRegistry, ballAsset, staticData);
            var generator = new RandomLevelGenerator(ballViewFactory, staticData);
            
            staticData.Load();
            generator.Generate(_center.position, _amountOfBalls, _radius);
        }
    }
}