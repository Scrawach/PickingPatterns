using Npc.Common;
using Npc.Components;
using Npc.Npc.States;
using Npc.Services;
using UnityEngine;

namespace Npc.Npc
{
    public class NpcBehaviour : MonoBehaviour
    {
        [SerializeField] private AgentMove _agent;
        [SerializeField] private float _workingTimeInSeconds;
        [SerializeField] private float _restingTimeInSeconds;
        [SerializeField] private Transform _workingPlace;
        [SerializeField] private Transform _restingPlace;
        
        private StateMachine _stateMachine;
        
        private void Start()
        {
            var location = new SingleLocation(_workingPlace.position, _restingPlace.position);
            _stateMachine = new StateMachine();
            _stateMachine.AddMany
            (
                new MoveToWorkPlace(_stateMachine, _agent, location),
                new Working(_stateMachine, new Timer(_workingTimeInSeconds)),
                new MoveToRestPlace(_stateMachine, _agent, location),
                new Resting(_stateMachine, new Timer(_restingTimeInSeconds))
            );
            _stateMachine.Enter<MoveToWorkPlace>();
        }

        private void Update() => 
            _stateMachine.Update();
    }
}