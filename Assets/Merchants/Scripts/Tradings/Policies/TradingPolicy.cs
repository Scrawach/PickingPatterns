using System;
using Merchants.Gameplay;
using Merchants.Gameplay.PlayerLogic;

namespace Merchants.Tradings.Policies
{
    public class TradingPolicy : ITradingPolicy
    {
        private readonly Func<Player, bool> _playerTradeFunc;
        private readonly ITrading _trading;

        public TradingPolicy(ITrading trading, Func<Player, bool> playerTradeFunc)
        {
            _trading = trading;
            _playerTradeFunc = playerTradeFunc;
        }

        public void StartTrade() => 
            _trading.StartTrade();

        public bool CanTradeWith(Player target) => 
            _playerTradeFunc(target);
    }
}