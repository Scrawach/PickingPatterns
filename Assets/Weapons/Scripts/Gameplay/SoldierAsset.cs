using Weapons.AssetsManagement;

namespace Weapons.Gameplay
{
    public class SoldierAsset : Asset<Soldier>
    {
        private const string PathToSoldier = "Soldier";
        
        public SoldierAsset(IAssets assets) 
            : base(PathToSoldier, assets) { }
    }
}