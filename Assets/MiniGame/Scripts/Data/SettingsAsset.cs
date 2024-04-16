using MiniGame.Scripts.AssetManagement;

namespace MiniGame.Scripts.Data
{
    public class SettingsAsset : Asset<MiniGameSettings>
    {
        private const string PathToSettings = "Settings";
        
        public SettingsAsset(IAssets assets) 
            : base(PathToSettings, assets) { }
    }
}