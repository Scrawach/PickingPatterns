using System.Collections.Generic;
using MiniGame.Scripts.AssetManagement;
using MiniGame.Scripts.Data;
using MiniGame.Scripts.Gameplay.Balls;
using MiniGame.Scripts.Gameplay.Balls.View;
using MiniGame.Scripts.Gameplay.Conditions;
using MiniGame.Scripts.Gameplay.Generators;
using MiniGame.Scripts.Gameplay.Picker;
using MiniGame.Scripts.Random;
using MiniGame.Scripts.UI;
using MiniGame.Scripts.UserInput;
using UnityEngine;

namespace MiniGame.Scripts
{
    public class MiniGameBootstrapper : MonoBehaviour
    {
        private GameUI _gameUI;
        
        private void Awake()
        {
            var assets = new ResourcesAssets();
            var gameSettings = new SettingsAsset(assets);
            var staticData = new StaticData(gameSettings);
            var ballRegistry = new BallRegistry();
            var ballAsset = new BallAsset(assets);
            var ballViewFactory = new BallViewFactory(ballRegistry, ballAsset, staticData);

            var random = new UnityRandom();
            var generator = new RandomLevelGenerator(ballViewFactory, staticData, random);

            var unityInput = new UnityInput(Camera.main);
            var ballPickerAsset = new BallPickerAsset(assets);
            var pickerFactory = new BallPickerFactory(unityInput, ballPickerAsset);

            var redPickedCondition = new PickedConcreteBalls(ballRegistry, BallType.Red);
            var greenPickedCondition = new PickedConcreteBalls(ballRegistry, BallType.Green);
            var whitePickedCondition = new PickedConcreteBalls(ballRegistry, BallType.White);
            var allPickedCondition = new PickedAllBalls(ballRegistry);
            var conditions = new Dictionary<ConditionType, IWinCondition>()
            {
                [ConditionType.PickedAll] = allPickedCondition,
                [ConditionType.PickedRed] = redPickedCondition,
                [ConditionType.PickedGreen] = greenPickedCondition,
                [ConditionType.PickedWhite] = whitePickedCondition
            };

            var selectedCondition = new SelectedCondition(conditions);
            var game = new MiniGame(ballRegistry, pickerFactory, ballViewFactory, generator, staticData, selectedCondition);

            var uiAsset = new UIRootAsset(assets);
            var uiFactory = new UIFactory(uiAsset);

            _gameUI = new GameUI(game, selectedCondition, uiFactory);
        }

        private void Start() => 
            _gameUI.Start();

        private void OnDestroy() => 
            _gameUI.Stop();
    }
}