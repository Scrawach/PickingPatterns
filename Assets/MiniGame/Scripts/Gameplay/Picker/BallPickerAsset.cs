using MiniGame.Scripts.AssetManagement;

namespace MiniGame.Scripts.Gameplay.Picker
{
    public class BallPickerAsset : Asset<BallPicker>
    {
        private const string PathToPicker = "BallPicker";
        
        public BallPickerAsset(IAssets assets) 
            : base(PathToPicker, assets) { }
    }
}