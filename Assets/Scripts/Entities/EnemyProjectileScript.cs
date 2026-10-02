using UnityEngine;

namespace Midterm
{
    public class EnemyProjectileScript : MonoBehaviour
    {
        public float speed;
        public float damage;
        private bool damaged;
        private string playerTag = "Player";

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
