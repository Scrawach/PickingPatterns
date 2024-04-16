using System.Linq;
using MiniGame.Scripts.Gameplay.Balls;

namespace MiniGame.Scripts.Gameplay.Conditions
{
    public class PickedConcreteBalls : IWinCondition
    {
        private readonly BallRegistry _registry;
        private readonly BallType _targetType;

        public PickedConcreteBalls(BallRegistry registry, BallType targetType)
        {
            _registry = registry;
            _targetType = targetType;
        }

        public bool IsHappened() => 
            _registry
                .AllOf(_targetType)
                .All(ball => ball.IsPicked);
    }
}