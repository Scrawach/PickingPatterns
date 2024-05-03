using System;
using System.Collections.Generic;
using Npc.Npc.States;

namespace Npc.Npc
{
    public class StateMachine : IStateSwitcher
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _current;

        public StateMachine() => 
            _states = new Dictionary<Type, IState>();

        public void AddMany(params IState[] states)
        {
            foreach (var state in states) 
                _states[state.GetType()] = state;
        }

        public void Update() => 
            _current?.Update();

        public void Enter<TState>() where TState : IState
        {
            _current?.Exit();
            _current = _states[typeof(TState)];
            _current.Enter();
        }
    }
}