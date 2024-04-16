using System;
using MiniGame.Scripts.Data;
using MiniGame.Scripts.Gameplay.Balls;
using MiniGame.Scripts.Gameplay.Balls.View;
using MiniGame.Scripts.Gameplay.Conditions;
using MiniGame.Scripts.Gameplay.Generators;
using MiniGame.Scripts.Gameplay.Picker;

namespace MiniGame.Scripts
{
    public class MiniGame
    {
        private readonly BallRegistry _ballRegistry;
        private readonly BallPickerFactory _pickerFactory;
        private readonly BallViewFactory _viewFactory;
        private readonly RandomLevelGenerator _generator;
        private readonly StaticData _staticData;
        private readonly IWinCondition _winCondition;

        private BallPicker _picker;

        public MiniGame(BallRegistry registry, BallPickerFactory pickerFactory, BallViewFactory viewFactory,
            RandomLevelGenerator generator, StaticData staticData, IWinCondition winCondition)
        {
            _ballRegistry = registry;
            _pickerFactory = pickerFactory;
            _viewFactory = viewFactory;
            _generator = generator;
            _staticData = staticData;
            _winCondition = winCondition;
        }

        public event Action Completed;

        public void Start()
        {
            _staticData.Load();
            _generator.Generate();
            _picker = _pickerFactory.Create();
            
            _picker.Picked += OnBallPicked;
        }
        
        public void Stop()
        {
            _ballRegistry.Clear();
            _viewFactory.Clear();
            
            _picker.Picked -= OnBallPicked;
            _pickerFactory.Clear();
        }

        private void OnBallPicked()
        {
            if (_winCondition.IsHappened()) 
                Completed?.Invoke();
        }
    }
}