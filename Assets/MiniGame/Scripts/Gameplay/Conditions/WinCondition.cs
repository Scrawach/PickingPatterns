using System;
using MiniGame.Scripts.Gameplay.Balls;
using Zenject;

namespace MiniGame.Scripts.Gameplay.Conditions
{
    public class WinCondition : IWinCondition, IInitializable
    {
        private readonly WinConditionProvider _winConditionProvider;
        private readonly BallRegistry _ballRegistry;

        private IWinCondition _winCondition;
        
        public WinCondition(WinConditionProvider winConditionProvider, BallRegistry ballRegistry)
        {
            _winConditionProvider = winConditionProvider;
            _ballRegistry = ballRegistry;
        }

        public void Initialize() =>
            _winCondition = _winConditionProvider.Type switch
            {
                ConditionType.PickedAll => new PickedAllBalls(_ballRegistry),
                _ => new PickedConcreteBalls(_ballRegistry, ParseCondition(_winConditionProvider.Type))
            };

        public bool IsHappened() => 
            _winCondition.IsHappened();

        private static BallType ParseCondition(ConditionType condition) =>
            condition switch
            {
                ConditionType.PickedRed => BallType.Red,
                ConditionType.PickedGreen => BallType.Green,
                ConditionType.PickedWhite => BallType.White,
                _ => throw new ArgumentOutOfRangeException(nameof(condition), condition, null)
            };
    }
}