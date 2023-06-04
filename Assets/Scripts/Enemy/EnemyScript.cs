using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems;

public class EnemyScript : MonoBehaviour
{
    public GameObject healthSpherePrefab;
    public float attackDamage = 10f;
    public float attackRange = 1f;
    public float attackCooldown = 1f;
    public LayerMask attackLayer;
    public Transform player;
    private Animator animator;
    private bool canAttack = true;
    private static readonly int Attack = Animator.StringToHash("Attack");
    


    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (canAttack && IsPlayerInRange())
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    public void SpawnSphere()
    {
        Instantiate(healthSpherePrefab, transform.position, Quaternion.identity);
    }

    private bool IsPlayerInRange()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        return distance <= attackRange;
    }

    private IEnumerator AttackCoroutine()
    {
        canAttack = false;

        
        animator.SetBool(Attack, true);

        yield return new WaitForSeconds(0.75f);

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange, attackLayer);
        foreach (Collider hitCollider in hitColliders)
        {
            HealthSystem healthSystem = hitCollider.GetComponent<HealthSystem>();
            if (healthSystem != null)
            {
                healthSystem.TakeDamage(attackDamage, true);
            }
        }

        yield return new WaitForSeconds(attackCooldown);

        
        animator.SetBool(Attack, false);

        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
