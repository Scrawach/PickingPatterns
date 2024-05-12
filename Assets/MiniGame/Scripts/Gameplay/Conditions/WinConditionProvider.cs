namespace MiniGame.Scripts.Gameplay.Conditions
{
    public class WinConditionProvider
    {
        public WinConditionProvider(ConditionType type) => 
            Type = type;

        public ConditionType Type { get; private set; }
    }
}