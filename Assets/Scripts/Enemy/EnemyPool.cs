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

        [SerializeField] private BulletSpawnSystem bulletSpawnSystem;

        [Header("Pool")] 
        [SerializeField] private Transform container;

        [SerializeField] private GameObject enemyPrefab;

        private readonly Queue<GameObject> enemyPool = new();

        private void Awake()
        {
            for (var i = 0; i < maxEnemiesCount; i++)
            {
                var enemy = Instantiate(enemyPrefab, container);
                enemyPool.Enqueue(enemy);
            }
        }

        public bool TryGetEnemy(GameObject target, out GameObject enemy)
        {
            if (!enemyPool.TryDequeue(out enemy))
            {
                return false;
                
            }
            enemy.transform.SetParent(worldTransform);

            var spawnPosition = enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);

            enemy.GetComponent<EnemyAttackAgent>().SetTarget(target);
            enemy.GetComponent<WeaponComponent>().Init(bulletSpawnSystem);
            enemy.GetComponent<HitPointsComponent>().Init();
            return true;
            }


        public void Release(GameObject enemy)
        {
            enemy.transform.SetParent(container);
            enemyPool.Enqueue(enemy);
        }
    }
}