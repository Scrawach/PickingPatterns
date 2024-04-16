using Merchants.AssetManagement;

namespace Merchants.Gameplay.Merchants
{
    public class MerchantAsset : Asset<MerchantView>
    {
        private const string PathToMerchant = "Merchant";
        
        public MerchantAsset(IAssets assets) 
            : base(PathToMerchant, assets) { }
    }
}