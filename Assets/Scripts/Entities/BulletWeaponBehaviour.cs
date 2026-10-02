using UnityEngine;
using UnityEngine.UIElements;

namespace Midterm
{
    public class BulletWeaponBehaviour : IWeaponBehaviour
    {
        ShootInteractor shootInteractor;
        Transform shootPoint;
        GameObject player;
        
        public BulletWeaponBehaviour(ShootInteractor _interactor)
        {
            shootInteractor = _interactor;
            shootPoint = _interactor.GetShootPoint();
            shootInteractor.GetWeaponRenderer().material.color = Color.purple;
            player = GameObject.FindGameObjectWithTag("Player");
        }

        public void FireWeapon()
        {
            PooledObject pooledBullet = ObjectPool.Instance.GetPooledBullet();

            if (pooledBullet != null)
            {
                pooledBullet.gameObject.SetActive(true);

                //Get the Rigidbody and set the position and rotation of the bullet
                Rigidbody bullet = pooledBullet.GetComponent<Rigidbody>();
                bullet.transform.position = shootPoint.position;
                bullet.transform.LookAt(shootPoint.forward);                
                bullet.transform.forward = shootPoint.forward;
                bullet.freezeRotation = true;

                //Apply a force to the bullet
                bullet.linearVelocity = shootPoint.forward * shootInteractor.GetShootVelocity();

                //Recycle the bullet with the object pool
                pooledBullet.DestroyWithTime(2f);
            }
        }
    }
}
