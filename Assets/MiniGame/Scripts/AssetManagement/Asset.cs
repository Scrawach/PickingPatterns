using UnityEngine;

namespace MiniGame.Scripts.AssetManagement
{
    public class Asset<TAsset> : IAsset<TAsset> where TAsset : Object
    {
        private readonly string _pathToAsset;
        private readonly IAssets _assets;

        public Asset(string pathToAsset, IAssets assets)
        {
            _pathToAsset = pathToAsset;
            _assets = assets;
        }

        public TAsset Load() => 
            _assets.Load<TAsset>(_pathToAsset);

        public TAsset Instantiate(Vector3 at, Quaternion rotation) => 
            Object.Instantiate(Load(), at, rotation);
    }
}