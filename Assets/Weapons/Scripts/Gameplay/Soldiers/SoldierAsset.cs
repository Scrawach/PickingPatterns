using Weapons.AssetsManagement;
using Weapons.Gameplay.Soldiers.View;

namespace Weapons.Gameplay.Soldiers
{
    public class SoldierViewAsset : Asset<SoldierView>
    {
        private const string PathToSoldier = "Soldier";
        
        public SoldierViewAsset(IAssets assets) 
            : base(PathToSoldier, assets) { }
    }
}