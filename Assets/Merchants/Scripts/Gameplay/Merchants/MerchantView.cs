using Merchants.Gameplay.PlayerLogic;
using UnityEngine;

namespace Merchants.Gameplay.Merchants
{
    public class MerchantView : MonoBehaviour
    {
        private Merchant _merchant;

        public void Construct(Merchant merchant) => 
            _merchant = merchant;

        public void TradeWith(Player player)
        {
            var trading = _merchant.TradeWith(player);
            trading.StartTrade();
        }
    }
}