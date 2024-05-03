using UnityEngine;

namespace Coins.Scripts
{
    public class CoinsBootstrapper : MonoBehaviour
    {
        [SerializeField] private CoinCooldownSpawner _cooldownSpawner;
        [SerializeField] private Coin _coinPrefab;
        [SerializeField] private Transform[] _spawnPoints;

        private void Start()
        {
            var uniquePoints = new UniquePoints(_spawnPoints);
            var coinSpawner = new CoinSpawner(_coinPrefab, uniquePoints);
            _cooldownSpawner.Construct(coinSpawner);
        }
    }
}