using UnityEngine;

namespace MiniGame.Scripts.Random
{
    public class UnityRandom : IRandom
    {
        public UnityRandom() { }
        
        public UnityRandom(int seed = 0) => 
            UnityEngine.Random.InitState(seed);

        public int Range(int minInclusive, int maxExclusive) => 
            UnityEngine.Random.Range(minInclusive, maxExclusive);

        public Vector2 InsideUnitCircle(float unitSize = 1) => 
            UnityEngine.Random.insideUnitCircle * unitSize;
    }
}