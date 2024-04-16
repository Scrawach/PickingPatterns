namespace Merchants.Gameplay.PlayerLogic
{
    public class Player
    {
        public Player(Reputation reputation) => 
            Reputation = reputation;
        
        public Reputation Reputation { get; }
    }
}