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

            if (_controller.canAttack)
            {
                /*PooledObject pooledLaser = ObjectPool.Instance.GetPooledObject();

                if (pooledLaser != null)
                {
                    pooledLaser.gameObject.SetActive(true);

                    ProjectileScript projectileScript = pooledLaser.GetComponent<ProjectileScript>();
                    projectileScript.Initialize(_controller.gameObject.tag);

                    //Get the Rigidbody and set the position and rotation of the bullet
                    Rigidbody projectile = pooledLaser.GetComponent<Rigidbody>();
                    projectile.transform.position = _controller.projectileSpawnReference.transform.position;
                    projectile.transform.rotation = _controller.transform.rotation;

                    //Apply a force to the bullet
                    projectile.linearVelocity = _controller.transform.forward * projectileScript.speed;

                    //Recycle the bullet with the object pool
                    pooledLaser.DestroyWithTime(2f);
                }*/

                GameObject laser = GameObject.Instantiate(_controller.projectilePrefab,_controller.projectileSpawnReference.transform.position,_controller.transform.rotation);
                laser.transform.LookAt(_controller.target.transform);
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