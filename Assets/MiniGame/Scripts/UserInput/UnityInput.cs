using MiniGame.Scripts.CameraLogic;
using MiniGame.Scripts.Gameplay.Balls.View;
using UnityEngine;

namespace MiniGame.Scripts.UserInput
{
    public class UnityInput : IInput
    {
        private readonly CameraProvider _camera;

        public UnityInput(CameraProvider camera) => 
            _camera = camera;

        public bool IsPickedBall(out BallView view)
        {
            if (Input.GetMouseButton(0))
            {
                var mousePosition = Input.mousePosition;
                var ray = _camera.MainCamera.ScreenPointToRay(mousePosition);
                var raycast = Physics.Raycast(ray, out var hit);

                if (raycast && hit.collider.TryGetComponent(out view))
                    return true;
            }

            view = null;
            return false;
        }
    }
}