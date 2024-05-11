using System.Collections.Generic;
using UnityEngine;

namespace PureSpawner.Gameplay.Services
{
    public interface ILevelService
    {
        IEnumerable<Transform> GetEnemySpawnPoints();
    }
}