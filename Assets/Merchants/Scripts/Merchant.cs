using Merchants.Gameplay;
using Merchants.Gameplay.PlayerLogic;
using Merchants.Tradings;

namespace Merchants
{
    public class Merchant
    {
        private readonly TradingFactory _factory;

        public Merchant(TradingFactory factory) => 
            _factory = factory;

        public ITrading TradeWith(Player target) => 
            _factory.For(target);
    }
}