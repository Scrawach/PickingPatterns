using Merchants.AssetManagement;

namespace Merchants.Gameplay.PlayerLogic
{
    public class PlayerAsset : Asset<PlayerView>
    {
        private const string PathToPlayer = "Player";
        
        public PlayerAsset(IAssets assets) 
            : base(PathToPlayer, assets) { }
    }
}