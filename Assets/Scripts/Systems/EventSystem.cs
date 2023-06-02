using System;
using UnityEngine;

namespace Systems
{
    public class EventSystem : MonoBehaviour
    {
        public static Action<float,float> OnHealthChanged;
    
        public static void HealthChanged(float currentHealth, float maxHealth)
        {
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }
        public static Action OnKill;
        
        public static void AddScore()
        {
            OnKill?.Invoke();
        }
    }
}
