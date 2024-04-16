using UnityEngine;

namespace MiniGame.Scripts.Gameplay.Balls.View
{
    public class BallView : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;

        private BallViewFactory _factory;
        private Ball _ball;

        public void Construct(BallViewFactory factory, Ball ball, Material material)
        {
            _factory = factory;
            _ball = ball;
            _renderer.material = material;
        }

        public void Pick()
        {
            _ball.Pick();
            _factory.Destroy(this);
        }
    }
}