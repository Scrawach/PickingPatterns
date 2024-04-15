using System;
using UnityEngine;
using Weapons.AssetsManagement;
using Weapons.Gameplay;
using Weapons.Gameplay.Bullets;
using Weapons.Gameplay.Weapons;
using Weapons.UserInput;

namespace Weapons
{
    public class WeaponsBootstrapper : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private WeaponId _equippedWeapon;
        [SerializeField] private int _amountOfAmmo;
        
        private void Awake()
        {
            var unityInput = new KeyboardInput();
            var resources = new ResourcesAssets();
            var bullet = new BulletAsset(resources);
            var weaponFactory = new WeaponWithAmmoFactory(CreateWeaponFactory(_equippedWeapon, bullet), _amountOfAmmo);
            var soldier = new SoldierAsset(resources);
            var soldierFactory = new SoldierFactory(unityInput, soldier, weaponFactory);
            
            soldierFactory.Create(_spawnPoint.position);
        }

        private IWeaponFactory CreateWeaponFactory(WeaponId id, BulletAsset bullet) =>
            id switch
            {
                WeaponId.Rifle => new RifleFactory(bullet),
                WeaponId.Shotgun => new ShotgunFactory(bullet),
                WeaponId.EndlessAmmo => new EndlessAmmoWeaponFactory(bullet),
                _ => throw new ArgumentOutOfRangeException(nameof(id), id, null)
            };
    }
}