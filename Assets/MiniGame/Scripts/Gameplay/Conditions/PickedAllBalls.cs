using System.Linq;
using MiniGame.Scripts.Gameplay.Balls;

namespace MiniGame.Scripts.Gameplay.Conditions
{
    public class PickedAllBalls : IWinCondition
    {
        private readonly BallRegistry _registry;

        public PickedAllBalls(BallRegistry registry) => 
            _registry = registry;

        public bool IsHappened() => 
            _registry
                .All()
                .All(ball => ball.IsPicked);
    }
}