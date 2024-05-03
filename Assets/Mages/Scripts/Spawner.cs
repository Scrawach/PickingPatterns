using System;
using System.Collections;
using Mages.Units;
using UnityEngine;

namespace Mages
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float _delaySpawnInSeconds = 1f;
        [SerializeField] private Transform _mageSpawnPoint;
        [SerializeField] private Transform _paladinSpawnPoint;
        
        private IUnitFactory _factory;
        private Coroutine _spawning;

        public void Construct(IUnitFactory factory) => 
            _factory = factory;

        public void StartSpawning()
        {
            StopSpawning();
            _spawning = StartCoroutine(Spawning());
        }

        public void StopSpawning()
        {
            if (_spawning != null)
                StopCoroutine(_spawning);
        }

        private IEnumerator Spawning()
        {
            var delay = new WaitForSeconds(_delaySpawnInSeconds);
            
            while (true)
            {
                yield return delay;
                _factory.CreateMage(_mageSpawnPoint.position).CastSpell();
                _factory.CreatePaladin(_paladinSpawnPoint.position).AttackTarget();
            }
        }
    }
}