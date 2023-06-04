using System.Collections;
using Systems;
using UnityEngine;

namespace Character
{
    public class AttackScript : MonoBehaviour
    {
        public float attackDamage = 10f;
        public float attackRange = 2f;
        public float attackCooldown = 1f; 
        private Animator animator;
        private bool canAttack = true;
        private HealthSystem healthSystem;

        private void Start()
        {
            animator = GetComponent<Animator>();
            healthSystem = GetComponent<HealthSystem>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && canAttack)
            {
                StartCoroutine(AttackCoroutine());
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                healthSystem.TakeDamage(5, true);
            }
        }

        private IEnumerator AttackCoroutine()
        {
            canAttack = false;

            animator.SetTrigger("Attack");

            // return new WaitForSeconds(1.5f);

        
            bool enemyInFront = CheckEnemyInFront();

            if (enemyInFront)
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);
                foreach (Collider hitCollider in hitColliders)
                {
                    if (hitCollider.CompareTag("Enemy"))
                    {
                        HealthSystem enemyHealth = hitCollider.GetComponent<HealthSystem>();
                        if (enemyHealth != null)
                        {
                            enemyHealth.TakeDamage(attackDamage, false);
                        }
                    }
                }
            }

            yield return new WaitForSeconds(attackCooldown);

            canAttack = true;
        }

        private bool CheckEnemyInFront()
        {
            Vector3 direction = transform.forward;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, attackRange))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
