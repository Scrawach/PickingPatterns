using System;
using Merchants.Gameplay;
using Merchants.Gameplay.PlayerLogic;
using Merchants.Tradings.Policies;

namespace Merchants.Tradings
{
    public class TradingFactory
    {
        private readonly ITradingPolicy[] _tradings;

        public TradingFactory(params ITradingPolicy[] tradings) => 
            _tradings = tradings;

        public ITrading For(Player player)
        {
            foreach (var trading in _tradings)
            {
                if (trading.CanTradeWith(player))
                    return trading;
            }

            throw new ArgumentOutOfRangeException($"{nameof(For)} in Trading Policies");
        }
    }
}