using Npc.Components;
using Npc.Services;

namespace Npc.Npc.States
{
    public class MoveToRestPlace : IState
    {
        private readonly IStateSwitcher _switcher;
        private readonly AgentMove _agent;
        private readonly ILocation _location;

        public MoveToRestPlace(IStateSwitcher switcher, AgentMove agent, ILocation location)
        {
            _switcher = switcher;
            _agent = agent;
            _location = location;
        }

        public void Enter()
        {
            var workPosition = _location.NearestRestingPlace(_agent.transform.position);
            _agent.MoveTo(workPosition);
        }

        public void Update()
        {
            if (_agent.IsPositionReached)
                _switcher.Enter<Resting>();
        }

        public void Exit()
        {
            _agent.Stop();
        }
    }
}