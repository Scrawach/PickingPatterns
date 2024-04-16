using UnityEngine;

namespace MiniGame.Scripts.Random
{
    public interface IRandom
    {
        int Range(int minInclusive, int maxExclusive);
        Vector2 InsideUnitCircle(float unitSize = 1f);
    }
}