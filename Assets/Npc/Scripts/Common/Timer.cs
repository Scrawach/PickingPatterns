using UnityEngine;

namespace Npc.Common
{
    public class Timer
    {
        public Timer(float target) => 
            Target = target;

        public float Target { get; }

        public float Elapsed { get; private set; }
        
        public bool IsDone { get; private set; }
        
        public void Tick(float delta)
        {
            Elapsed = Mathf.Clamp(Elapsed + delta, 0, Target);
            IsDone = Elapsed >= Target;
        }
        
        public void Clear()
        {
            Elapsed = 0;
            IsDone = false;
        }
    }
}