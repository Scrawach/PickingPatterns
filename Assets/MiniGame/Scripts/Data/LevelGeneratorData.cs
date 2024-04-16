using System;
using UnityEngine;

namespace MiniGame.Scripts.Data
{
    [Serializable]
    public class LevelGeneratorData
    {
        public Vector3 Center;
        public int AmountOfBalls;
        public int FieldRadius;
    }
}