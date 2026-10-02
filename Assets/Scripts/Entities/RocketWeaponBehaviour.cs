using UnityEngine;

namespace Midterm
{
    public class RocketWeaponBehaviour : IWeaponBehaviour
    {
        ShootInteractor shootInteractor;
        Transform shootPoint;
        public RocketWeaponBehaviour(ShootInteractor _interactor)
        {
            shootInteractor = _interactor;
            shootPoint = _interactor.GetShootPoint();

            shootInteractor.GetWeaponRenderer().material.color = Color.green;
        }

        public void FireWeapon()
        {
            PooledObject pooledRocket = ObjectPool.Instance.GetPooledRocket();

            if (pooledRocket != null)
            {
                pooledRocket.gameObject.SetActive(true);

                //Get the Rigidbody and set the position and rotation of the bullet
                Rigidbody rocket = pooledRocket.GetComponent<Rigidbody>();
                rocket.transform.position = shootPoint.position;
                rocket.transform.LookAt(shootPoint.forward);
                rocket.transform.forward = shootPoint.forward;
                rocket.freezeRotation = true;

                //Apply a force to the bullet
                rocket.linearVelocity = shootPoint.forward * shootInteractor.GetShootVelocity();

                //Recycle the bullet with the object pool
                pooledRocket.DestroyWithTime(2f);
            }
        }
    }
}
