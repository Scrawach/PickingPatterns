using System;
using UnityEngine;
using Weapons.Gameplay.Bullets;

namespace Weapons.Gameplay.Weapons
{
    public class Rifle : IWeapon
    {
        private readonly Transform _shootPoint;
        private readonly BulletAsset _bullet;
        
        private int _ammo;

        public Rifle(Transform shootPoint, BulletAsset bullet)
        {
            _shootPoint = shootPoint;
            _bullet = bullet;
        }

        public bool HasAmmo() => 
            _ammo > 0;

        public void AddAmmo(int amountOfAmmo)
        {
            if (amountOfAmmo < 0)
                throw new ArgumentOutOfRangeException($"{nameof(AddAmmo)}: {nameof(amountOfAmmo)} should be positive!");

            _ammo += amountOfAmmo;
        }

        public void Shoot()
        {
            if (_ammo < 1)
                throw new Exception("Has not ammo!");

            _ammo--;
            _bullet.Instantiate(_shootPoint.position, _shootPoint.rotation);
            Debug.Log($"Shot single bullet...");
        }
    }
}