using UnityEngine;

namespace MiniGame.Scripts.CameraLogic
{
    public class CameraProvider
    {
        public Camera MainCamera { get; private set; }

        public void SetMainCamera(Camera camera) => 
            MainCamera = camera;
    }
}