using PureSpawner.Gameplay.Enemies.Components;
using UnityEngine;

namespace PureSpawner.Gameplay.Enemies.Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "EnemyConfigs/Config")]
    public class EnemyConfig: ScriptableObject
    {
        [field: SerializeField] public EnemyType EnemyType { get; private set; }
        [field: SerializeField] public Enemy Prefab { get; private set; }
        [field: SerializeField, Range(1, 10)] public int Health { get; private set; }
        [field: SerializeField, Range(1, 10)] public float Speed { get; private set; }
    }
}