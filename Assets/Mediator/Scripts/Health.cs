using System;
using UnityEngine;

namespace Mediator.Scripts
{
    public class Health
    {
        public Health(int total) 
            : this(total, total)
        { }
        
        public Health(int current, int total)
        {
            Current = current;
            Total = total;
        }
        
        public int Current { get; private set; }
        
        public int Total { get; private set; }

        public float Ratio => 
            (float) Current / Total;

        public event Action Changed;
        
        public void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException($"{nameof(damage)} must be greater than 0!");

            Current = Mathf.Clamp(Current - damage, 0, Total);
            Changed?.Invoke();
        }

        public void FullRestore()
        {
            Current = Total;
            Changed?.Invoke();
        }
    }
}