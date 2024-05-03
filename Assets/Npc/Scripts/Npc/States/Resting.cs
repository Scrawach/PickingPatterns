using Npc.Common;
using UnityEngine;

namespace Npc.Npc.States
{
    public class Resting : IState
    {
        private readonly IStateSwitcher _switcher;
        private readonly Timer _restingTimer;

        public Resting(IStateSwitcher switcher, Timer restingTimer)
        {
            _switcher = switcher;
            _restingTimer = restingTimer;
        }
        
        public void Enter() { }

        public void Update()
        {
            _restingTimer.Tick(Time.deltaTime);
            
            if (_restingTimer.IsDone)
                _switcher.Enter<MoveToWorkPlace>();
        }

        public void Exit() => 
            _restingTimer.Clear();
    }
}