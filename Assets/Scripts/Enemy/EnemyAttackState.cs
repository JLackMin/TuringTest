using UnityEngine;
using System.Collections;

namespace Midterm
{
    public class EnemyAttackState : EnemyState
    {
        public EnemyAttackState(EnemyController enemyController) : base(enemyController)
        {
            _controller = enemyController;
        }

        public override void OnStateEntered()
        {
            Debug.Log("Enemy has entered Attack state.");
        }

        public override void OnStateUpdate()
        {
            Debug.Log("Attack updating...");

            if (_controller.canAttack)
            {
                GameObject bullet = GameObject.Instantiate(_controller.projectilePrefab,_controller.projectileSpawnReference.transform.position,Quaternion.identity);   
                _controller.StartCoroutine(AttackDelay());
            }
        
            float distance = Vector3.Distance(_controller.transform.position,_controller.target.transform.position);

            if (distance > _controller.attackRange)
            {
                _controller.ChangeState(new EnemyFollowState(_controller));
            }        
        }

        public override void OnStateExit()
        {
            Debug.Log("Enemy has exited Attack state.");
        }

        public IEnumerator AttackDelay()
        {
            _controller.canAttack = false;
            yield return new WaitForSeconds(2f);
            _controller.canAttack = true;
        }
    }
}