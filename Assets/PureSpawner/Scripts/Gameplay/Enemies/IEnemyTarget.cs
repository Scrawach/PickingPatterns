using UnityEngine;

namespace PureSpawner.Gameplay.Enemies
{
    public interface IEnemyTarget : IDamageable
    {
        Vector3 Position { get; }
    }
}