using System;
using UnityEngine;

namespace Visitor.Scripts.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        public event Action<Enemy> Died;

        public void MoveTo(Vector3 position) =>
            transform.position = position;

        public abstract void Accept(IEnemyVisitor visitor);
        
        public void Kill()
        {
            Died?.Invoke(this);
            Destroy(gameObject);
        }
    }
}