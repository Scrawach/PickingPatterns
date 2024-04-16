using UnityEngine;
using Weapons.AssetsManagement;
using Weapons.Gameplay.Bullets;
using Weapons.Gameplay.Soldiers;
using Weapons.Gameplay.Soldiers.View;
using Weapons.Gameplay.Weapons;
using Weapons.UserInput;

namespace Weapons
{
    public class WeaponsBootstrapper : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private int _amountOfAmmo;
        
        private void Awake()
        {
            var unityInput = new KeyboardInput();
            var resources = new ResourcesAssets();
            var bullet = new BulletAsset(resources);
            var weaponFactory = new WeaponInventoryFactory(bullet, _amountOfAmmo);
            var soldierView = new SoldierViewAsset(resources);
            var soldierFactory = new SoldierFactory(weaponFactory);
            var soldierViewFactory = new SoldierViewFactory(unityInput, soldierView, soldierFactory);
            
            soldierViewFactory.Create(_spawnPoint.position);
        }
    }
}