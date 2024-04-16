using UnityEngine;

namespace Merchants.AssetManagement
{
    public interface IAssets
    {
        TAsset Load<TAsset>(string path) where TAsset : Object;
    }
}