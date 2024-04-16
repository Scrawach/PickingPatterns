using System.Collections.Generic;
using UnityEngine;
using Weapons.Gameplay.Bullets;

namespace Weapons.Gameplay.Weapons
{
    public class WeaponInventoryFactory
    {
        private readonly BulletAsset _bulletAsset;
        private readonly int _amountOfAmmo;

        public WeaponInventoryFactory(BulletAsset bulletAsset, int amountOfAmmo)
        {
            _bulletAsset = bulletAsset;
            _amountOfAmmo = amountOfAmmo;
        }

        public WeaponInventory Create(Transform shootPoint)
        {
            var weapons = new Dictionary<int, IWeapon>()
            {
                [1] = new Rifle(shootPoint, _bulletAsset),
                [2] = new Shotgun(shootPoint, _bulletAsset),
                [3] = new EndlessAmmoWeapon(shootPoint, _bulletAsset)
            };

            foreach (var weapon in weapons.Values) 
                weapon.AddAmmo(_amountOfAmmo);

            return new WeaponInventory(weapons);
        }
    }
}