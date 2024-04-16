using UnityEngine;

namespace MiniGame.Scripts.AssetManagement
{
    public interface IAsset<out TAsset> where TAsset : Object
    {
        TAsset Instantiate(Vector3 at, Quaternion rotation);
    }
}