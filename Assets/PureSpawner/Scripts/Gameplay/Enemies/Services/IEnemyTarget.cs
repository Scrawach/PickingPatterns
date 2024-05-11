using UnityEngine;

namespace PureSpawner.Gameplay.Enemies.Services
{
    public interface IEnemyTarget
    {
        Vector3 Position { get; }
    }
}