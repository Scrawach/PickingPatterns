using System.Collections.Generic;
using UnityEngine;

namespace PureSpawner.Gameplay.Enemies.Configs
{
    [CreateAssetMenu(fileName = "Enemy Spawner Config", menuName = "EnemyConfigs/Spawner Config")]
    public class EnemySpawnerConfig : ScriptableObject
    {
        [field: SerializeField] public float Cooldown { get; private set; }
        [field: SerializeField] public List<Vector3> SpawnPoints { get; private set; }
    }
}