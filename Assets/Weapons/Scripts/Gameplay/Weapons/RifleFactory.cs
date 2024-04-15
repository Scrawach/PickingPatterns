using UnityEngine;
using Weapons.Gameplay.Bullets;

namespace Weapons.Gameplay.Weapons
{
    public class RifleFactory : IWeaponFactory
    {
        private readonly BulletAsset _bullet;

        public RifleFactory(BulletAsset bullet) => 
            _bullet = bullet;

        public IWeapon Create(Transform shootPoint) => 
            new Rifle(shootPoint, _bullet);
    }
}