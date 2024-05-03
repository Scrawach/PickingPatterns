using System;

namespace Stats.Scripts
{
    public class RaceStatsProvider : IStatsProvider
    {
        private readonly RaceType _targetRace;

        public RaceStatsProvider(RaceType targetRace) => 
            _targetRace = targetRace;

        public Stats Create() =>
            _targetRace switch
            {
                RaceType.Human => new Stats(10, 10, 10),
                RaceType.Orc => new Stats(15, 5, 10),
                RaceType.Elf => new Stats(5, 12, 13),
                _ => throw new ArgumentOutOfRangeException()
            };
    }
}