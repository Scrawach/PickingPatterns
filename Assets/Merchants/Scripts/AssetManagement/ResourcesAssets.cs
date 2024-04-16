using UnityEngine;

namespace Merchants.AssetManagement
{
    public class ResourcesAssets : IAssets
    {
        public TAsset Load<TAsset>(string path) where TAsset : Object => 
            Resources.Load<TAsset>(path);
    }
}