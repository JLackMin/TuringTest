using UnityEngine;

namespace Midterm
{
    public class EnemyFollowState : EnemyState
    {
        public EnemyFollowState(EnemyController enemyController) : base(enemyController)
        {
            _controller = enemyController;
        }

        public override void OnStateEntered()
        {
            Debug.Log("Enemy has entered Follow state.");
        }

        public override void OnStateUpdate()
        {
            Debug.Log("Follow updating...");

            _controller.gameObject.transform.position = Vector3.MoveTowards(_controller.gameObject.transform.position,_controller.target.transform.position,_controller.moveSpeed * Time.deltaTime);
            _controller.gameObject.transform.LookAt(_controller.target.transform.position);
            
            float distance = Vector3.Distance(_controller.transform.position,_controller.target.transform.position);

            if (distance <= _controller.attackRange)
            {
                OnStateExit();
                _controller.ChangeState(new EnemyAttackState(_controller));
            }

            if (distance > _controller.detectionRange)
            {
                _controller.ChangeState(new EnemyIdleState(_controller));
            }
        }

        public override void OnStateExit()
        {
            Debug.Log("Enemy has exited Follow state.");
        }
    }
}