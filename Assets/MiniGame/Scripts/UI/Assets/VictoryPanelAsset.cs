using MiniGame.Scripts.AssetManagement;
using MiniGame.Scripts.UI.View;

namespace MiniGame.Scripts.UI.Assets
{
    public class VictoryPanelAsset : Asset<VictoryPanel>
    {
        private const string PathToVictoryPanel = "VictoryPanel";

        public VictoryPanelAsset(IAssets assets) 
            : base(PathToVictoryPanel, assets) { }
    }
}