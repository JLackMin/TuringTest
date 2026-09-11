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
            PooledObject pooledRocket = ObjectPool.Instance.GetPooledObject();

            if (pooledRocket != null)
            {
                pooledRocket.gameObject.SetActive(true);

                ProjectileScript projectileScript = pooledRocket.GetComponent<ProjectileScript>();
                //projectileScript.Initialize(shootInteractor.gameObject.tag);

                //Get the Rigidbody and set the position and rotation of the bullet
                Rigidbody rocket = pooledRocket.GetComponent<Rigidbody>();
                rocket.transform.position = shootPoint.position;
                rocket.transform.rotation = shootPoint.rotation;

                //Apply a force to the bullet
                rocket.linearVelocity = shootPoint.forward * shootInteractor.GetShootVelocity();

                //Recycle the bullet with the object pool
                pooledRocket.DestroyWithTime(2f);
            }
        }
    }
}
