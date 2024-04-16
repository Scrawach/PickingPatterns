using UnityEngine;

namespace MiniGame.Scripts.UI
{
    public class UIFactory
    {
        private readonly UIRootAsset _asset;

        public UIFactory(UIRootAsset asset) => 
            _asset = asset;

        public UIRoot CreateUIRoot() => 
            _asset.Instantiate(Vector3.zero, Quaternion.identity);
    }
}