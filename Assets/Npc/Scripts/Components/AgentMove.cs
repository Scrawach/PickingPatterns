using UnityEngine;
using UnityEngine.AI;

namespace Npc.Components
{
    public class AgentMove : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;

        public bool IsPositionReached { get; private set; }

        public void MoveTo(Vector3 position)
        {
            _agent.destination = position;
            _agent.isStopped = false;
        }

        private void Update()
        {
            var distanceToPosition = Vector3.Distance(transform.position, _agent.destination);
            IsPositionReached = distanceToPosition <= _agent.stoppingDistance;
        }

        public void Stop() => 
            _agent.isStopped = true;
    }
}