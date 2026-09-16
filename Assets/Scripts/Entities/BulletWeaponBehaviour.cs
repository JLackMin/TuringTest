using UnityEngine;

namespace Midterm
{
    public class BulletWeaponBehaviour : IWeaponBehaviour
    {
        ShootInteractor shootInteractor;
        Transform shootPoint;
        
        public BulletWeaponBehaviour(ShootInteractor _interactor)
        {
            shootInteractor = _interactor;
            shootPoint = _interactor.GetShootPoint();

            shootInteractor.GetWeaponRenderer().material.color = Color.purple;
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
                bullet.transform.rotation = shootPoint.rotation;

                //Apply a force to the bullet
                bullet.linearVelocity = shootPoint.forward * shootInteractor.GetShootVelocity();

                //Recycle the bullet with the object pool
                pooledBullet.DestroyWithTime(2f);
            }
        }
    }
}
