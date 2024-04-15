using Weapons.AssetsManagement;

namespace Weapons.Gameplay.Bullets
{
    public class BulletAsset : Asset<Bullet>
    {
        private const string PathToBulletPrefab = "Bullet";
        
        public BulletAsset(IAssets assets) 
            : base(PathToBulletPrefab, assets) { }
    }
}