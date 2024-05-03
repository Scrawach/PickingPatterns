using Npc.Npc.States;

namespace Npc.Npc
{
    public interface IStateSwitcher
    {
        void Enter<TState>() where TState : IState;
    }
}