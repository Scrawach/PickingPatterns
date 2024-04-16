using UnityEngine;

namespace Merchants.Tradings
{
    public class NoTrading : ITrading
    {
        public void StartTrade() => 
            Debug.Log($"I don't want trade with you!");
    }
}