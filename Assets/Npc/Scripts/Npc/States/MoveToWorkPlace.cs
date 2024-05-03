using Npc.Components;
using Npc.Services;

namespace Npc.Npc.States
{
    public class MoveToWorkPlace : IState
    {
        private readonly IStateSwitcher _switcher;
        private readonly AgentMove _agent;
        private readonly ILocation _location;

        public MoveToWorkPlace(IStateSwitcher switcher, AgentMove agent, ILocation location)
        {
            _switcher = switcher;
            _agent = agent;
            _location = location;
        }

        public void Enter()
        {
            var workPosition = _location.NearestWorkingPlace(_agent.transform.position);
            _agent.MoveTo(workPosition);
        }

        public void Update()
        {
            if (_agent.IsPositionReached)
                _switcher.Enter<Working>();
        }

        public void Exit()
        {
            _agent.Stop();
        }
    }
}