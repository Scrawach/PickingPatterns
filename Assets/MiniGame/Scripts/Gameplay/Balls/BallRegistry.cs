using System.Collections.Generic;
using System.Linq;

namespace MiniGame.Scripts.Gameplay.Balls
{
    public class BallRegistry
    {
        private readonly Dictionary<BallType, List<Ball>> _balls;

        public BallRegistry() => 
            _balls = new Dictionary<BallType, List<Ball>>();

        public IEnumerable<Ball> All() => 
            _balls.Values.SelectMany(balls => balls);

        public IEnumerable<Ball> AllOf(BallType type) => 
            _balls[type];

        public void Add(Ball ball)
        {
            var type = ball.Type;
            
            if (_balls.ContainsKey(type) == false) 
                _balls[type] = new List<Ball>();

            _balls[type].Add(ball);
        }
    }
}