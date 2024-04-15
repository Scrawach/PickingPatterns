using UnityEngine;
using Weapons.Gameplay.Bullets;

namespace Weapons.Gameplay.Weapons
{
    public class EndlessAmmoWeaponFactory : IWeaponFactory
    {
        private readonly BulletAsset _bullet;

        public EndlessAmmoWeaponFactory(BulletAsset bullet) => 
            _bullet = bullet;

        public IWeapon Create(Transform shootPoint) => 
            new EndlessAmmoWeapon(shootPoint, _bullet);
    }
}