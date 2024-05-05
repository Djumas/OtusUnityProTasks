using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Spawn")] 
        [SerializeField] private EnemyPositions enemyPositions;

        [SerializeField] private int maxEnemiesCount = 7;

        [SerializeField] private Transform worldTransform;

        [Header("Pool")] 
        [SerializeField] private Transform container;

        [SerializeField] private GameObject enemyPrefab;

        private readonly Queue<GameObject> enemyPool = new();

        private void Awake()
        {
            for (var i = 0; i < maxEnemiesCount; i++)
            {
                var enemy = Instantiate(this.enemyPrefab, this.container);
                this.enemyPool.Enqueue(enemy);
            }
        }

        public GameObject SpawnEnemy(GameObject target)
        {
            if (!this.enemyPool.TryDequeue(out var enemy))
            {
                //Reached max count.
                return null;
            }

            enemy.transform.SetParent(this.worldTransform);

            var spawnPosition = this.enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = this.enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);

            enemy.GetComponent<EnemyAttackAgent>().SetTarget(target);
            
            return enemy;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(this.container);
            this.enemyPool.Enqueue(enemy);
        }
    }
}