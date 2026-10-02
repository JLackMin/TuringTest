using UnityEngine;

namespace Midterm
{
    public class ProjectileScript : MonoBehaviour
    {
        public float damage;
        private string enemyTag = "Enemy";

        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(enemyTag))
            {
                other.gameObject.GetComponent<Health>().TakeDamage(damage);
                CheckPooledObject();
            }
        }

        void CheckPooledObject()
        {
            PooledObject pooledObject = GetComponent<PooledObject>();

            if (pooledObject != null)
            {
                pooledObject.ResetObject();
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
