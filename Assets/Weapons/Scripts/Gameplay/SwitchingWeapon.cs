using System;
using System.Collections.Generic;
using UnityEngine;
using Weapons.Gameplay.Bullets;
using Weapons.Gameplay.Weapons;

namespace Weapons.Gameplay
{
    public class SwitchingWeapon : IWeapon
    {
        private readonly Dictionary<Type, IWeapon> _weapons;
        private IWeapon _current;

        public SwitchingWeapon(Transform shootPoint, BulletAsset bullet)
        {
            _weapons = new Dictionary<Type, IWeapon>
            {
                [typeof(Rifle)] = new Rifle(shootPoint, bullet),
                [typeof(Shotgun)] = new Shotgun(shootPoint, bullet),
                [typeof(EndlessAmmoWeapon)] = new EndlessAmmoWeapon(shootPoint, bullet)
            };
        }

        public void SwitchTo<TWeapon>() where TWeapon : IWeapon
        {
            var weaponType = typeof(TWeapon);

            if (_weapons.TryGetValue(weaponType, out var weapon))
                _current = weapon;
            else
                throw new ArgumentOutOfRangeException($"{nameof(SwitchTo)}: {weaponType} not exist!");
        }
        
        public bool HasAmmo() => 
            _current.HasAmmo();

        public void AddAmmo(int amountOfAmmo) => 
            _current.AddAmmo(amountOfAmmo);

        public void Shoot() => 
            _current.Shoot();
    }
}