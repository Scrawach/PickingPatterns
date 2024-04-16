using UnityEngine;
using Weapons.Gameplay.Weapons;

namespace Weapons.Gameplay.Soldiers
{
    public class SoldierFactory
    {
        private readonly WeaponInventoryFactory _weaponFactory;
        
        public SoldierFactory(WeaponInventoryFactory weaponFactory) => 
            _weaponFactory = weaponFactory;

        public Soldier Create(Transform shootPoint) => 
            new Soldier(_weaponFactory.Create(shootPoint));
    }
}