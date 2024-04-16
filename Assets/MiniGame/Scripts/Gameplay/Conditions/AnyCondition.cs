using System.Linq;

namespace MiniGame.Scripts.Gameplay.Conditions
{
    public class AnyCondition : IWinCondition
    {
        private readonly IWinCondition[] _conditions;

        public AnyCondition(params IWinCondition[] conditions) => 
            _conditions = conditions;

        public bool IsHappened() => 
            _conditions.Any(condition => condition.IsHappened());
    }
}