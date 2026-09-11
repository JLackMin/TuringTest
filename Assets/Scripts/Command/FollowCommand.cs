using UnityEngine;
using UnityEngine.AI;

namespace Midterm
{
    public class FollowCommand : Command
    {
        private NavMeshAgent agent;
        private Vector3 playerPosition;

        public FollowCommand(NavMeshAgent _agent, Vector3 _playerPosition)
        {
            agent = _agent;
            playerPosition = _playerPosition;
        }

        public override void Execute()
        {
            agent.SetDestination(playerPosition);
        }

        public override bool isComplete => ReachedPlayer();

        bool ReachedPlayer()
        {
            if (agent.remainingDistance > 0.1f)
            {
                return false;
            }
            return true;
        }
    }
}
