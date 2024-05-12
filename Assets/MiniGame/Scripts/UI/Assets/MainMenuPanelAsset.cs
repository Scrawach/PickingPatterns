using MiniGame.Scripts.AssetManagement;
using MiniGame.Scripts.UI.View;

namespace MiniGame.Scripts.UI.Assets
{
    public class MainMenuPanelAsset : Asset<MainMenuPanel>
    {
        private const string PathToMainMenu = "MainMenuPanel";
        
        public MainMenuPanelAsset(IAssets assets) 
            : base(PathToMainMenu, assets) { }
    }
}