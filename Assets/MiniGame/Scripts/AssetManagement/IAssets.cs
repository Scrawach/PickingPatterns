using UnityEngine;

namespace MiniGame.Scripts.AssetManagement
{
    public interface IAssets
    {
        TAsset Load<TAsset>(string path) where TAsset : Object;
    }
}