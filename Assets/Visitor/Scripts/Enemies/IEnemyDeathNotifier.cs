using System;

namespace Visitor.Scripts.Enemies
{
    public interface IEnemyDeathNotifier
    {
        event Action<Enemy> Died;
    }
}