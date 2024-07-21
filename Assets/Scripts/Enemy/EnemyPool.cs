using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Spawn")] [SerializeField] private EnemyPositions enemyPositions;
        [SerializeField] private int maxEnemiesCount = 7;
        [SerializeField] private Transform worldTransform;
        [ShowInInspector, ReadOnly] private BulletSpawnSystem _bulletSpawnSystem;

        [Header("Pool")] [SerializeField] private Transform container;
        [SerializeField] private GameObject enemyPrefab;

        private readonly Queue<GameObject> _enemyPool = new();

        [Inject]
        public void Construct(BulletSpawnSystem bulletSpawnSystem)
        {
            _bulletSpawnSystem = bulletSpawnSystem;
        }

        private void Awake()
        {
            for (var i = 0; i < maxEnemiesCount; i++)
            {
                var enemy = Instantiate(enemyPrefab, container);
                _enemyPool.Enqueue(enemy);
            }
        }

        public bool TryGetEnemy(GameObject target, out GameObject enemy)
        {
            if (!_enemyPool.TryDequeue(out enemy))
            {
                return false;
            }

            enemy.transform.SetParent(worldTransform);

            var spawnPosition = enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);

            enemy.GetComponent<EnemyAttackAgent>().SetTarget(target);
            enemy.GetComponent<WeaponComponent>().Init(_bulletSpawnSystem);
            enemy.GetComponent<HitPointsComponent>().Init();
            return true;
        }

        public void Release(GameObject enemy)
        {
            enemy.transform.SetParent(container);
            _enemyPool.Enqueue(enemy);
        }
    }
}