using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

namespace Midterm
{
    public class Health : MonoBehaviour
    {
        public float currentHealth = 100f;

        public event Action<float> OnHealthChanged;
        public event Action OnDeath;

        void Start()
        {
            OnHealthChanged?.Invoke(currentHealth); 
        }

        public void TakeDamage(float amount)
        {
            currentHealth -= amount;
            OnHealthChanged?.Invoke(currentHealth);

            if (currentHealth <= 0f)
            {
                Die();
            }
        }

        public void Die()
        {
            OnDeath?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
