using MiniGame.Scripts.Gameplay.Balls.View;

namespace MiniGame.Scripts.Gameplay.Picker
{
    public interface IInput
    {
        bool IsPickedBall(out BallView view);
    }
}