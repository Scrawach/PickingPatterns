using PureSpawner.Gameplay.Enemies.Services;
using UnityEngine;

namespace PureSpawner.Gameplay
{
    public class TargetPoint : MonoBehaviour, IEnemyTarget
    {
        public Vector3 Position => transform.position;
    }
}