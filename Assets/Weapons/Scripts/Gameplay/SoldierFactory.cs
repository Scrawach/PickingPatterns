using UnityEngine;
using Weapons.AssetsManagement;
using Weapons.Gameplay.Weapons;
using Weapons.UserInput;

namespace Weapons.Gameplay
{
    public class SoldierFactory
    {
        private readonly IInput _input;
        private readonly SoldierAsset _soldier;
        private readonly IWeaponFactory _weaponFactory;

        public SoldierFactory(IInput input, SoldierAsset soldier, IWeaponFactory weaponFactory)
        {
            _input = input;
            _soldier = soldier;
            _weaponFactory = weaponFactory;
        }

        public Soldier Create(Vector3 position)
        {
            var instance = _soldier.Instantiate(position, Quaternion.identity);
            instance.Construct(_input, _weaponFactory.Create(instance.ShootPoint));
            return instance;
        }
    }
}