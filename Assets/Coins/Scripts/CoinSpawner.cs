using UnityEngine;

namespace Coins.Scripts
{
    public class CoinSpawner
    {
        private readonly Coin _prefab;
        private readonly UniquePoints _points;

        public CoinSpawner(Coin prefab, UniquePoints points)
        {
            _prefab = prefab;
            _points = points;
        }

        public bool TrySpawn()
        {
            if (_points.HasNotTakenPoint())
            {
                Spawn();
                return true;
            }

            return false;
        }

        private void Spawn()
        {
            var randomPoint = _points.GetRandomPoint();
            var coin = Object.Instantiate(_prefab, randomPoint.position, randomPoint.rotation, randomPoint);
            coin.Collected += OnCoinCollected;
        }

        private void OnCoinCollected(Coin coin)
        {
            _points.UnTaken(coin.transform.parent);
            coin.Collected -= OnCoinCollected;
            Object.Destroy(coin.gameObject);
        }
    }
}