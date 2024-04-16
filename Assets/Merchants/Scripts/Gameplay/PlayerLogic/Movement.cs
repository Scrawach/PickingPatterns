using UnityEngine;

namespace Merchants.Gameplay.PlayerLogic
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        public void Move(Vector3 direction)
        {
            var moveStep = _speed * Time.deltaTime;
            transform.Translate(direction * moveStep);
        }
    }
}