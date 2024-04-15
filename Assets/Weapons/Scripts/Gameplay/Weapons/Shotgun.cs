using System;
using UnityEngine;
using Weapons.Gameplay.Bullets;

namespace Weapons.Gameplay.Weapons
{
    public class Shotgun : IWeapon
    {
        private const int MaxBulletsForShoot = 3;
        private const int SpreadAngleBetweenBullets = 25;
        
        private readonly Transform _shootPoint;
        private readonly BulletAsset _bulletAsset;

        private int _ammo;

        public Shotgun(Transform shootPoint, BulletAsset bulletAsset)
        {
            _shootPoint = shootPoint;
            _bulletAsset = bulletAsset;
        }

        public bool HasAmmo() => 
            _ammo > 2;
        
        public void AddAmmo(int amountOfAmmo)
        {
            if (amountOfAmmo < 0)
                throw new ArgumentOutOfRangeException($"{nameof(AddAmmo)}: {nameof(amountOfAmmo)} should be positive!");

            _ammo += amountOfAmmo;
        }

        public void Shoot()
        {
            var startAngle = new Vector3(0, -SpreadAngleBetweenBullets, 0);
            for (var i = 0; i < MaxBulletsForShoot; i++)
            {
                _ammo--;
                var rotation = Quaternion.Euler(startAngle);
                startAngle.y += SpreadAngleBetweenBullets;
                _bulletAsset.Instantiate(_shootPoint.position, rotation);
            }
        }
    }
}