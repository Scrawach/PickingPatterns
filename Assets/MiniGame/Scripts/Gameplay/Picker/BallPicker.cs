using System;
using MiniGame.Scripts.UserInput;
using UnityEngine;

namespace MiniGame.Scripts.Gameplay.Picker
{
    public class BallPicker : MonoBehaviour
    {
        private IInput _input;

        public void Construct(IInput input) => 
            _input = input;

        public event Action Picked;
        
        private void Update()
        {
            if (_input.IsPickedBall(out var view))
            {
                view.Pick();
                Picked?.Invoke();
            }
        }
    }
}