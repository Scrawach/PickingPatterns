using UnityEngine;

namespace Mages.AssetManagement
{
    public class InstantiateFactory
    {
        private readonly Assets _assets;

        public InstantiateFactory(Assets assets) => 
            _assets = assets;

        public TObject Instantiate<TObject>(string path, Vector3 position, Quaternion rotation, Transform parent)
            where TObject : Object
        {
            var prefab = _assets.Load<TObject>(path);
            return Object.Instantiate(prefab, position, rotation, parent);
        }
    }
}