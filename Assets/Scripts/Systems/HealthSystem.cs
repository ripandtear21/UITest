using UnityEngine;

namespace Systems
{
    public class HealthSystem: MonoBehaviour
    {
        [SerializeField]private float maxHealth;
        [SerializeField]private float currentHealth;
        
        public void Initialize(float maxHealth)
        {
            this.maxHealth = maxHealth;
            currentHealth = maxHealth;
        }
        public void IncreaseMaxHealth(float amount)
        {
            maxHealth += amount;
            currentHealth = maxHealth;
        }

        public void TakeDamage(float damageAmount)
        {
            currentHealth -= damageAmount;
            if (gameObject.CompareTag("Player"))
            {
                EventSystem.HealthChanged(currentHealth, maxHealth);
            }
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();
            }
            
            Debug.Log("Health reduced to: " + currentHealth);
        }

        public void Heal(float healAmount)
        {
            currentHealth += healAmount;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            Debug.Log("Health increased to: " + currentHealth);
        }
        

        private void Die()
        {
            gameObject.SetActive(false);
            if (gameObject.CompareTag("Enemy"))
            {
                EventSystem.AddScore();
            }
        }
        public float GetHealthPercentage()
        {
            return (float)currentHealth / maxHealth;
        }
    }
}

