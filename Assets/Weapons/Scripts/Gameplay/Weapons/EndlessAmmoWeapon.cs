using UnityEngine;
using Weapons.Gameplay.Bullets;

namespace Weapons.Gameplay.Weapons
{
    public class EndlessAmmoWeapon : IWeapon
    {
        private readonly Transform _shootPoint;
        private readonly BulletAsset _bullet;

        public EndlessAmmoWeapon(Transform shootPoint, BulletAsset bullet)
        {
            _shootPoint = shootPoint;
            _bullet = bullet;
        }

        public bool HasAmmo() => 
            true;
        
        public void AddAmmo(int amountOfAmmo) { }

        public void Shoot() => 
            _bullet.Instantiate(_shootPoint.position, _shootPoint.rotation);
    }
}