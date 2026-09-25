using UnityEngine;

namespace Midterm
{
    public class ProjectileScript : MonoBehaviour
    {
        public float damage;
        public float speed;
        private string enemyTag = "Enemy";
        private string playerTag = "Player";
        private bool damaged;
      
        void Update()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        void OnTriggerEnter(Collider other)
        {
            Health health = other.GetComponent<Health>();

            if (health != null && !damaged && other.gameObject.CompareTag(playerTag))
            {
                health.TakeDamage(damage);
                damaged = true;
            }
        }

        void OnTriggerExit(Collider other)
        {
            damaged = false;
            CheckPooledObject();
        }

        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(enemyTag))
            {
                other.gameObject.GetComponent<Health>().TakeDamage(damage);
            }

            CheckPooledObject();
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
