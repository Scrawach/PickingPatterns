using Weapons.Gameplay.Weapons;

namespace Weapons.Gameplay.Soldiers
{
    public class Soldier
    {
        private readonly WeaponInventory _inventory;
        private IWeapon _currentWeapon;

        public Soldier(WeaponInventory inventory) => 
            _inventory = inventory;

        public ShootResult TryShoot()
        {
            if (_currentWeapon == null)
                return ShootResult.HasNoWeapon;

            if (_currentWeapon.HasAmmo() == false)
                return ShootResult.HasNoAmmo;

            _currentWeapon.Shoot();
            return ShootResult.Success;
        }

        public WeaponSwitchResult SwitchWeapon(int slotId)
        {
            if (_inventory.Has(slotId) == false)
                return WeaponSwitchResult.HasNotWeaponAtSlot;

            _currentWeapon = _inventory.Get(slotId);
            return WeaponSwitchResult.Success;
        }
    }
}