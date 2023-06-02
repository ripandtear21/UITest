using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems;

public class EnemyScript : MonoBehaviour
{
    private HealthSystem healthSystem;
    [SerializeField] private int maxHealth;

    private void Start()
    {
        healthSystem = new HealthSystem(maxHealth);
    }
}
