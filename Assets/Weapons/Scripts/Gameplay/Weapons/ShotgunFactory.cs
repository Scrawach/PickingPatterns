using UnityEngine;
using Weapons.Gameplay.Bullets;

namespace Weapons.Gameplay.Weapons
{
    public class ShotgunFactory : IWeaponFactory
    {
        private readonly BulletAsset _bullet;

        public ShotgunFactory(BulletAsset bullet) => 
            _bullet = bullet;

        public IWeapon Create(Transform shootPoint) => 
            new Shotgun(shootPoint, _bullet);
    }
}