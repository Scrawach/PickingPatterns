using UnityEngine;

namespace Weapons.UserInput
{
    public class KeyboardInput : IInput
    {
        public bool ShootPressed() => 
            Input.GetKeyDown(KeyCode.Q);
    }
}