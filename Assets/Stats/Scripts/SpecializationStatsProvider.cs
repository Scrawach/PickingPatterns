using System;

namespace Stats.Scripts
{
    public class SpecializationStatsProvider : IStatsProvider
    {
        private readonly SpecializationType _targetSpecialization;
        private readonly IStatsProvider _origin;

        public SpecializationStatsProvider(SpecializationType targetSpecialization, IStatsProvider origin)
        {
            _targetSpecialization = targetSpecialization;
            _origin = origin;
        }

        public Stats Create() =>
            _origin.Create() * SpecializationStats();

        private Stats SpecializationStats() =>
            _targetSpecialization switch
            {
                SpecializationType.Warrior => new Stats(2, 1, 1),
                SpecializationType.Mage => new Stats(1, 2, 1),
                SpecializationType.Rogue => new Stats(1, 1, 2),
                _ => throw new ArgumentOutOfRangeException()
            };
    }
}