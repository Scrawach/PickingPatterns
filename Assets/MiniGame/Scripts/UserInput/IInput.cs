using MiniGame.Scripts.Gameplay.Balls.View;

namespace MiniGame.Scripts.UserInput
{
    public interface IInput
    {
        bool IsPickedBall(out BallView view);
    }
}