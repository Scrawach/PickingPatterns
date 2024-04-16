using System.Linq;

namespace MiniGame.Scripts.Gameplay.Conditions
{
    public class AllCondition : IWinCondition
    {
        private readonly IWinCondition[] _conditions;

        public AllCondition(params IWinCondition[] conditions) => 
            _conditions = conditions;

        public bool IsHappened() => 
            _conditions.All(condition => condition.IsHappened());
    }
}