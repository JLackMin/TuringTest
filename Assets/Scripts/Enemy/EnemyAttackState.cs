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
            _controller.gameObject.transform.LookAt(_controller.target.transform.position);
            _controller.gameObject.transform.rotation.Set(0,0,_controller.gameObject.transform.rotation.y,0);

            if (_controller.canAttack)
            {
                PooledObject pooledLaser = ObjectPool.Instance.GetPooledLaser();

                if (pooledLaser != null)
                {
                    pooledLaser.gameObject.SetActive(true);

                    //Get the Rigidbody and set the position and rotation of the bullet
                    Rigidbody laser = pooledLaser.GetComponent<Rigidbody>();
                    laser.transform.position = _controller.projectileSpawnReference.transform.position;
                    laser.transform.rotation = Quaternion.identity;
                    laser.transform.LookAt(_controller.target.transform);

                    _controller.StartCoroutine(AttackDelay(pooledLaser));
                }
            
                float distance = Vector3.Distance(_controller.transform.position,_controller.target.transform.position);

                if (distance > _controller.attackRange)
                {
                    _controller.ChangeState(new EnemyFollowState(_controller));
                }        
            }
        }

        public override void OnStateExit()
        {
            Debug.Log("Enemy has exited Attack state.");
        }

        public IEnumerator AttackDelay(PooledObject laser)
        {
            _controller.canAttack = false;
            yield return new WaitForSeconds(2f);
            laser.ResetObject();
            _controller.canAttack = true;
        }
    }
}