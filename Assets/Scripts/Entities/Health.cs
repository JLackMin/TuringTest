using System;
using UnityEngine;
using UnityEngine.Events;

namespace Midterm
{
    public class Health : MonoBehaviour
    {
        public float currentHealth = 100f;

        public event Action<float> OnHealthChanged;
        public UnityEvent OnDeath;

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

        public void SetHealth(float value)
        {
            currentHealth = value;
            OnHealthChanged?.Invoke(currentHealth);
        }

        public void Die()
        {
            OnDeath?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
