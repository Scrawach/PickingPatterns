using UnityEngine;

namespace PureSpawner.Gameplay.Player
{
    [CreateAssetMenu(menuName = "Player/StatsConfig", fileName = "PlayerStatsConfig")]
    public class PlayerStatsConfig : ScriptableObject
    {
        [field: SerializeField, Range(1, 150)] public int MaxHealth { get; private set; }
    }
}