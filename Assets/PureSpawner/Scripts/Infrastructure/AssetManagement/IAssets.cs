using UnityEngine;

namespace PureSpawner.Infrastructure.AssetManagement
{
    public interface IAssets
    {
        TAsset[] LoadAll<TAsset>(string path) where TAsset : Object;
        TAsset Load<TAsset>(string path) where TAsset : Object;
    }
}