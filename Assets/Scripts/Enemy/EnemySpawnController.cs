using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemySpawnController : MonoBehaviour
    {
        [SerializeField] private EnemyPool enemyPool;
        [SerializeField] private GameObject target;
        [SerializeField] private BulletSpawnSystem bulletSpawnSystem;

        private readonly HashSet<GameObject> _activeEnemies = new();

        public bool TrySpawnEnemy(out GameObject enemy)
        {
            if (!enemyPool.TryGetEnemy(target, out enemy))
                return false;

            if (_activeEnemies.Add(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().OnHpEmpty += OnEnemyDestroyed;
            }

            return true;
        }

        private void OnEnemyDestroyed(GameObject enemy)
        {
            if (_activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().OnHpEmpty -= OnEnemyDestroyed;
                enemyPool.Release(enemy);
            }
        }
    }
}