namespace MiniGame.Scripts.Gameplay.Balls
{
    public class Ball
    {
        public Ball(BallType type) => 
            Type = type;

        public BallType Type { get; }

        public bool IsPicked { get; private set; }

        public void Pick() => 
            IsPicked = true;
    }
}