using UnityEngine;

namespace Coins.Scripts
{
    public class CoinCooldownSpawner : MonoBehaviour
    {
        [SerializeField] private float _delaySpawnInSeconds = 1f;
        
        private CoinSpawner _spawner;
        private float _elapsedTime;

        public void Construct(CoinSpawner spawner) => 
            _spawner = spawner;

        private void Update()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _delaySpawnInSeconds)
            {
                _elapsedTime -= _delaySpawnInSeconds;
                _spawner.TrySpawn();
            }
        }
    }
}