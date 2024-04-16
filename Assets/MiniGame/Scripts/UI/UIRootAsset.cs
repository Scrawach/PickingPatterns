using MiniGame.Scripts.AssetManagement;

namespace MiniGame.Scripts.UI
{
    public class UIRootAsset : Asset<UIRoot>
    {
        private const string PathToUIRoot = "UIRoot";
        
        public UIRootAsset(IAssets assets) 
            : base(PathToUIRoot, assets) { }
    }
}