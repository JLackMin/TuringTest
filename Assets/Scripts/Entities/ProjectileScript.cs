using UnityEngine;

namespace Midterm
{
    public class ProjectileScript : MonoBehaviour
    {
        public float damage;
        void OnTriggerEnter(Collider other)
        {
            Health health = other.GetComponent<Health>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }

            Destroy(this);
        }
    }
}
