using UnityEngine;

namespace PureSpawner.Infrastructure.AssetManagement
{
    public class ResourceAssets : IAssets
    {
        public TAsset[] LoadAll<TAsset>(string path) where TAsset : Object => 
            Resources.LoadAll<TAsset>(path);

        public TAsset Load<TAsset>(string path) where TAsset : Object => 
            Resources.Load<TAsset>(path);
    }
}