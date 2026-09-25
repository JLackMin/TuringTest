using UnityEngine;

namespace Midterm
{
    public class EnemyIdleState : EnemyState
    {
        public EnemyIdleState(EnemyController enemyController) : base(enemyController)
        {
            _controller = enemyController;
        }

        public override void OnStateEntered()
        {
            Debug.Log("Enemy has entered Idle state.");
        }

        public override void OnStateUpdate()
        {
            Debug.Log("Idle updating...");
            

            float distance = Vector3.Distance(_controller.transform.position,_controller.target.transform.position);
            Vector3 direction = (_controller.target.transform.position - _controller.transform.position).normalized;
            RaycastHit hit;

            if (distance <= _controller.detectionRange && GameManager.instance.currentGameState == GameManager.GameState.GamePlaying)
            {
                if (Physics.Raycast(_controller.transform.position, direction, out hit, _controller.detectionRange))
                {
                    if (hit.collider.gameObject == _controller.target)
                    {
                        _controller.ChangeState(new EnemyFollowState(_controller));
                    }
                }
            }
        }

        public override void OnStateExit()
        {
            Debug.Log("Enemy has exited Idle state.");
        }
    }
}