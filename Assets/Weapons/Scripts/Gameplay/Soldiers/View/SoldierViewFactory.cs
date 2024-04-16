using UnityEngine;
using Weapons.UserInput;

namespace Weapons.Gameplay.Soldiers.View
{
    public class SoldierViewFactory
    {
        private readonly IInput _input;
        private readonly SoldierViewAsset _asset;
        private readonly SoldierFactory _soldierFactory;

        public SoldierViewFactory(IInput input, SoldierViewAsset asset, SoldierFactory soldierFactory)
        {
            _input = input;
            _asset = asset;
            _soldierFactory = soldierFactory;
        }

        public SoldierView Create(Vector3 position)
        {
            var instance = _asset.Instantiate(position, Quaternion.identity);
            var soldier = _soldierFactory.Create(instance.ShootPoint);
            instance.Construct(_input, soldier);
            return instance;
        }
    }
}