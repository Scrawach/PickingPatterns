using System;

namespace Visitor.Scripts.Enemies
{
    public interface IEnemySpawnNotifier
    {
        event Action<Enemy> Spawned;
    }
}