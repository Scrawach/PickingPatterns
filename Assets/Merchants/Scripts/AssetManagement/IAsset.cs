using UnityEngine;

namespace Merchants.AssetManagement
{
    public interface IAsset<out TAsset> where TAsset : Object
    {
        TAsset Instantiate(Vector3 at, Quaternion rotation);
    }
}