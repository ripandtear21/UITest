using System.Collections;
using System.Collections.Generic;
using Systems;
using UnityEngine;

public class HealthSphereScript : MonoBehaviour
{
    [SerializeField] private float healAmount = 20f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthSystem playerHealth = other.GetComponent<HealthSystem>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
                
                Destroy(gameObject);
            }
        }
    }
}
