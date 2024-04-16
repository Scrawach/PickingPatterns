using System.Collections.Generic;

namespace Weapons.Gameplay.Weapons
{
    public class WeaponInventory
    {
        private readonly Dictionary<int, IWeapon> _weapons;

        public WeaponInventory(Dictionary<int, IWeapon> weapons) => 
            _weapons = weapons;

        public bool Has(int slot) => 
            _weapons.ContainsKey(slot);

        public IWeapon Get(int slot) => 
            _weapons[slot];
    }
}