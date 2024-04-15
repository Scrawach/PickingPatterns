using UnityEngine;

namespace Weapons.AssetsManagement
{
    public interface IAssets
    {
        TAsset Load<TAsset>(string path) where TAsset : Object;
    }
}