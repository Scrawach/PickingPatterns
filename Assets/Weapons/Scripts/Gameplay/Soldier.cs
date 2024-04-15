using UnityEngine;
using Weapons.Gameplay.Weapons;
using Weapons.UserInput;

namespace Weapons.Gameplay
{
    public class Soldier : MonoBehaviour
    {
        [field: SerializeField] public Transform ShootPoint { get; private set; }
        
        private IInput _input;
        private IWeapon _weapon;

        public void Construct(IInput input, IWeapon weapon)
        {
            _input = input;
            _weapon = weapon;
        }

        private void Update()
        {
            if (_input.ShootPressed())
                TryShoot();
        }

        private void TryShoot()
        {
            if (_weapon.HasAmmo())
                _weapon.Shoot();
            else
                Debug.Log($"Has not ammo!");
        }
    }
}