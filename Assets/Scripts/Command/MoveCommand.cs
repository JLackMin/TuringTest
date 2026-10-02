using UnityEngine;
using UnityEngine.AI;

namespace Midterm
{
    public class MoveCommand : Command
    {
        private NavMeshAgent agent;
        private Vector3 destination;
        int destinationLayer;
        bool hasRB;

        public MoveCommand(NavMeshAgent _agent, Vector3 _destination, int _destinationLayer)
        {
            agent = _agent;
            destination = _destination;
            destinationLayer = _destinationLayer;
        }

        public override void Execute()
        {
            agent.SetDestination(destination);
        }

        public override bool isComplete => ReachedDestination();

        bool ReachedDestination()
        {
            if (agent.remainingDistance > 0.1f)
            {
                return false;
            }

            if (destinationLayer == 12 && !hasRB)
            {
                Debug.Log("Adding rigidbody.");
                agent.gameObject.AddComponent<Rigidbody>();
                hasRB = true;
            }

            return true;
        }
    }
}
