using MiniGame.Scripts.Gameplay.Balls.View;
using UnityEngine;

namespace MiniGame.Scripts.Data
{
    [CreateAssetMenu(fileName = "MiniGameSettings", menuName = "MiniGameSettings", order = 0)]
    public class MiniGameSettings : ScriptableObject
    {
        public LevelGeneratorData GeneratorData;
        public BallMaterial[] Materials;
    }
}