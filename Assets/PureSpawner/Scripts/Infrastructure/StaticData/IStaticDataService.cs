using PureSpawner.Gameplay.Enemies;

namespace PureSpawner.Infrastructure.StaticData
{
    public interface IStaticDataService
    {
        EnemySpawnerConfig GetEnemySpawnerConfig();
    }
}