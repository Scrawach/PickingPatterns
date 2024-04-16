using System;
using MiniGame.Scripts.Gameplay.Balls.View;
using UnityEngine;

namespace MiniGame.Scripts.Gameplay.Picker
{
    public class UnityInput : IInput
    {
        private readonly Camera _camera;

        public UnityInput(Camera camera) => 
            _camera = camera;

        public bool IsPickedBall(out BallView view)
        {
            if (Input.GetMouseButton(0))
            {
                var mousePosition = Input.mousePosition;
                var ray = _camera.ScreenPointToRay(mousePosition);
                var raycast = Physics.Raycast(ray, out var hit);

                if (raycast && hit.collider.TryGetComponent(out view))
                    return true;
            }

            view = null;
            return false;
        }
    }
}