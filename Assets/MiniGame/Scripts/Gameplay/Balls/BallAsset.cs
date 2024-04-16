using MiniGame.Scripts.AssetManagement;
using MiniGame.Scripts.Gameplay.Balls.View;

namespace MiniGame.Scripts.Gameplay.Balls
{
    public class BallAsset : Asset<BallView>
    {
        private const string PathToBall = "Ball";
        
        public BallAsset(IAssets assets) 
            : base(PathToBall, assets) { }
    }
}