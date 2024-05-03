using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Coins.Scripts
{
    public class UniquePoints
    {
        private readonly SpawnPoint[] _points;

        public UniquePoints(IEnumerable<Transform> points) => 
            _points = points
                .Select(x => new SpawnPoint(x, false))
                .ToArray();

        public bool HasNotTakenPoint() => 
            _points.Any(x => x.IsTaken == false);

        public void UnTaken(Transform point)
        {
            foreach (var spawnPoint in _points)
            {
                if (spawnPoint.WorldPoint != point) 
                    continue;
                
                spawnPoint.IsTaken = false;
                break;
            }
        }
        
        public Transform GetRandomPoint()
        {
            var availablePoints = _points.Where(x => x.IsTaken == false).ToArray();
            var randomIndex = Random.Range(0, availablePoints.Length);
            var selected = availablePoints[randomIndex];
            selected.IsTaken = true;
            return selected.WorldPoint;
        }
    }
}