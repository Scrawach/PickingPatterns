namespace Stats.Scripts
{
    public class StatsFactory
    {
        public Stats Create(RaceType race, SpecializationType specialization, AbilityType ability) =>
            new AbilityStatsProvider
            (
                ability,
                new SpecializationStatsProvider
                (
                    specialization, 
                    new RaceStatsProvider(race)
                )
            ).Create();
    }
}