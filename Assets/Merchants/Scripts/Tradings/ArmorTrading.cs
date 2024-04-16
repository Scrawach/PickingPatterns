using UnityEngine;

namespace Merchants.Tradings
{
    public class ArmorTrading : ITrading
    {
        public void StartTrade() => 
            Debug.Log($"Trade armors...");
    }
}