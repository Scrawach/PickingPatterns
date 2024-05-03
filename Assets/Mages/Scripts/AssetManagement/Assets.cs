using UnityEngine;

namespace Mages.AssetManagement
{
    public class Assets
    {
        public TObject Load<TObject>(string path) where TObject : Object => 
            Resources.Load<TObject>(path);
    }
}