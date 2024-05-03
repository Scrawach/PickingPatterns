using System;
using UnityEngine;

namespace Visitor.Scripts.Enemies
{
    [CreateAssetMenu(fileName = "VisitorEnemyFactory", menuName = "Factory/VisitorEnemyFactory")]
    public class EnemyFactory: ScriptableObject
    {
        [SerializeField] private Human _humanPrefab;
        [SerializeField] private Elf _elfPrefab;

        public Enemy Get(EnemyType type) =>
            type switch
            {
                EnemyType.Elf => Instantiate(_elfPrefab),
                EnemyType.Human => Instantiate(_humanPrefab),
                _ => throw new ArgumentException(nameof(type))
            };
    }
}