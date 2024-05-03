using System;

namespace Stats.Scripts
{
    public class AbilityStatsProvider : IStatsProvider
    {
        private readonly AbilityType _targetAbility;
        private readonly IStatsProvider _origin;

        public AbilityStatsProvider(AbilityType targetAbility, IStatsProvider origin)
        {
            _targetAbility = targetAbility;
            _origin = origin;
        }
        
        public Stats Create() => 
            _origin.Create() + AbilityStats();

        private Stats AbilityStats() =>
            _targetAbility switch
            {
                AbilityType.StrengthBust => new Stats(2, 0, 0),
                AbilityType.IntelligenceBust => new Stats(0, 2, 0),
                AbilityType.DexterityBust => new Stats(0, 0, 2),
                _ => throw new ArgumentOutOfRangeException()
            };
    }
}