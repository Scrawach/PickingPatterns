using UnityEngine;

namespace MiniGame.Scripts.Gameplay.Picker
{
    public class BallPickerFactory
    {
        private readonly IInput _input;
        private readonly BallPickerAsset _asset;

        private BallPicker _picker;
        
        public BallPickerFactory(IInput input, BallPickerAsset asset)
        {
            _input = input;
            _asset = asset;
        }

        public BallPicker Create()
        {
            var instance = _asset.Instantiate(Vector3.zero, Quaternion.identity);
            instance.Construct(_input);
            _picker = instance;
            return instance;
        }

        public void Clear() => 
            Object.Destroy(_picker.gameObject);
    }
}