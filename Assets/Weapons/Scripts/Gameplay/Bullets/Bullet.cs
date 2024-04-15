using UnityEngine;

namespace Weapons.Gameplay.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        private void Update()
        {
            var moveStep = _speed * Time.deltaTime;
            transform.Translate(transform.forward * moveStep);
        }
    }
}