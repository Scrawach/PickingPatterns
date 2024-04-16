using System.Collections.Generic;

namespace MiniGame.Scripts.Gameplay.Conditions
{
    public class SelectedCondition : IWinCondition
    {
        private readonly Dictionary<ConditionType, IWinCondition> _conditions;
        private IWinCondition _current;

        public SelectedCondition(Dictionary<ConditionType, IWinCondition> conditions) => 
            _conditions = conditions;

        public void SwitchConditionTo(ConditionType conditionId) => 
            _current = _conditions[conditionId];

        public bool IsHappened() => 
            _current.IsHappened();
    }
}