using System;
using UnityEngine;

namespace Coins.Scripts
{
    public class Coin : MonoBehaviour
    {
        public event Action<Coin> Collected;

        private void OnTriggerEnter(Collider other) => 
            Collected?.Invoke(this);
    }
}