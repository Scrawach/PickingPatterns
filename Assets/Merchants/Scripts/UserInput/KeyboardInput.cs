using UnityEngine;

namespace Merchants.UserInput
{
    public class KeyboardInput : IInput
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";

        private readonly Camera _camera;

        public KeyboardInput(Camera camera) => 
            _camera = camera;

        public Vector3 MovementAxis
        {
            get
            {
                var axis = new Vector3(Input.GetAxis(HorizontalAxisName), 0, Input.GetAxis(VerticalAxisName));
                var transformedAxis = _camera.transform.TransformDirection(axis);
                transformedAxis.y = 0;
                return transformedAxis.normalized;
            }
        }

        public bool InteractPressed() => 
            Input.GetKeyDown(KeyCode.E);
    }
}