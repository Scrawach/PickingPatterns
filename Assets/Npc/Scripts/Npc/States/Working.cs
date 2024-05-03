using Npc.Common;
using UnityEngine;

namespace Npc.Npc.States
{
    public class Working : IState
    {
        private readonly IStateSwitcher _switcher;
        private readonly Timer _workingTimer;

        public Working(IStateSwitcher switcher, Timer workingTimer)
        {
            _switcher = switcher;
            _workingTimer = workingTimer;
        }
        
        public void Enter() { }

        public void Update()
        {
            _workingTimer.Tick(Time.deltaTime);
            
            if (_workingTimer.IsDone)
                _switcher.Enter<MoveToRestPlace>();
        }

        public void Exit() => 
            _workingTimer.Clear();
    }
}