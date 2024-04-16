using Merchants.Gameplay.PlayerLogic;

namespace Merchants.Tradings.Policies
{
    public interface ITradingPolicy : ITrading
    {
        bool CanTradeWith(Player target);
    }
}