using System;
using MiniGame.Scripts.Environment;
using MiniGame.Scripts.Gameplay.Conditions;
using MiniGame.Scripts.Gameplay.Picker;

namespace MiniGame.Scripts
{
    public class MiniGame
    {
        private readonly WorldBuilder _world;
        private readonly BallPickerFactory _pickerFactory;
        private readonly IWinCondition _winCondition;

        private BallPicker _picker;

        public MiniGame(WorldBuilder world, BallPickerFactory pickerFactory, IWinCondition winCondition)
        {
            _world = world;
            _pickerFactory = pickerFactory;
            _winCondition = winCondition;
        }

        public event Action Completed;

        public void Start()
        {
            _world.Build();
            
            _picker = _pickerFactory.Create();
            _picker.Picked += OnBallPicked;
        }
        
        public void Stop()
        {
            _world.Clear();
            
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