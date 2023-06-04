using System.Collections;
using System.Collections.Generic;
using Systems;
using UnityEngine;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject enemyPrefab;
        public int maxEnemies = 10;
        public float spawnRadius = 10f;
        public float spawnInterval = 1f;
        public Transform player;
        public float enemyMaxHealth = 100f;

        private List<GameObject> enemyPool;
        private bool isSpawning = false;

        private void Start()
        {
            enemyPool = new List<GameObject>();
            for (int i = 0; i < maxEnemies; i++)
            {
                GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                enemy.SetActive(false);

            
                HealthSystem healthSystem = enemy.GetComponent<HealthSystem>();
                if (healthSystem == null)
                {
                    healthSystem = enemy.AddComponent<HealthSystem>();
                }
                healthSystem.Initialize(enemyMaxHealth);

                enemyPool.Add(enemy);
            }
        }

        private void Update()
        {
            if (!isSpawning)
            {
                StartCoroutine(SpawnEnemies());
            }
        }

        private IEnumerator SpawnEnemies()
        {
            isSpawning = true;

            for (int i = 0; i < enemyPool.Count; i++)
            {
                GameObject enemy = enemyPool[i];
                if (!enemy.activeInHierarchy)
                {
                    if (!enemy.activeInHierarchy)
                    {
                        
                        Vector3 spawnPosition = GetRandomSpawnPosition();
                        enemy.transform.position = spawnPosition;
                        enemy.SetActive(true);

                        
                        HealthSystem healthSystem = enemy.GetComponent<HealthSystem>();
                        healthSystem.IncreaseMaxHealth(1f);
                    }
                }

                yield return new WaitForSeconds(spawnInterval);
            }

            isSpawning = false;
        }

        private Vector3 GetRandomSpawnPosition()
        {
            Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPosition = new Vector3(randomCircle.x, 0f, randomCircle.y) + player.position;
            return spawnPosition;
        }
    }
}
