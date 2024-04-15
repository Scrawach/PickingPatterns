using UnityEngine;

namespace Weapons.Gameplay.Weapons
{
    public class WeaponWithAmmoFactory : IWeaponFactory
    {
        private readonly IWeaponFactory _weaponFactory;
        private readonly int _amountOfAmmo;

        public WeaponWithAmmoFactory(IWeaponFactory weaponFactory, int amountOfAmmo)
        {
            _weaponFactory = weaponFactory;
            _amountOfAmmo = amountOfAmmo;
        }

        public IWeapon Create(Transform shootPoint)
        {
            var weapon = _weaponFactory.Create(shootPoint);
            weapon.AddAmmo(_amountOfAmmo);
            return weapon;
        }
    }
}