using UnityEngine;

namespace Coins.Scripts
{
    public class SpawnPoint
    {
        public Transform WorldPoint;
        public bool IsTaken;

        public SpawnPoint(Transform worldPoint, bool isTaken)
        {
            WorldPoint = worldPoint;
            IsTaken = isTaken;
        }
    }
}