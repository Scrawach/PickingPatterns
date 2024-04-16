using UnityEngine;

namespace MiniGame.Scripts.Gameplay.Balls.View
{
    public class BallView : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;
        
        private Ball _ball;

        public void Construct(Ball ball, Material material)
        {
            _ball = ball;
            _renderer.material = material;
        }
    }
}