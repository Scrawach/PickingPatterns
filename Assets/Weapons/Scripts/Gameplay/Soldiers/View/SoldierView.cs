using UnityEngine;
using Weapons.UserInput;

namespace Weapons.Gameplay.Soldiers.View
{
    public class SoldierView : MonoBehaviour
    {
        [field: SerializeField] public Transform ShootPoint { get; private set; }

        private IInput _input;
        private Soldier _soldier;

        public void Construct(IInput input, Soldier soldier)
        {
            _input = input;
            _soldier = soldier;
        }

        private void Update()
        {
            if (_input.ShootPressed())
            {
                var shootResult = _soldier.TryShoot();
                Debug.Log($"Shoot Result: {shootResult}");
            }

            if (_input.WeaponChanged(out var slotId))
            {
                var switchResult = _soldier.SwitchWeapon(slotId);
                Debug.Log($"Switch weapon result: {switchResult}");
            }
        }
    }
}