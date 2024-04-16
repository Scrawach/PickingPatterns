using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Weapons.UserInput
{
    public class KeyboardInput : IInput
    {
        private readonly Dictionary<KeyCode, int> _weaponSlotsKeys;

        public KeyboardInput()
        {
            _weaponSlotsKeys = new Dictionary<KeyCode, int>()
            {
                [KeyCode.Alpha1] = 1,
                [KeyCode.Alpha2] = 2,
                [KeyCode.Alpha3] = 3
            };
        }

        public bool ShootPressed() => 
            Input.GetKeyDown(KeyCode.Q);

        public bool WeaponChanged(out int slotId)
        {
            const int notValidSlot = -1;
            var pressedSlotKey = _weaponSlotsKeys.Keys.FirstOrDefault(Input.GetKeyDown);
            slotId = pressedSlotKey != default ? _weaponSlotsKeys[pressedSlotKey] : notValidSlot;
            return slotId != notValidSlot;
        }
    }
}