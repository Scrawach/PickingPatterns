using UnityEngine;

namespace Merchants.AssetManagement
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

        public TAsset Instantiate(Vector3 at, Quaternion rotation)
        {
            var prefab = _assets.Load<TAsset>(_pathToAsset);
            return Object.Instantiate(prefab, at, rotation);
        }
    }
}