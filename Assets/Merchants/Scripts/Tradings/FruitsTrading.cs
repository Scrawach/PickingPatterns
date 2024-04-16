using UnityEngine;

namespace Merchants.Tradings
{
    public class FruitsTrading : ITrading
    {
        public void StartTrade() => 
            Debug.Log($"Trade fruits...");
    }
}