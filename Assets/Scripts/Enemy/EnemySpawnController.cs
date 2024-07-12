using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public sealed class EnemySpawnController : MonoBehaviour
    {
        private EnemyPool _enemyPool;
        [SerializeField] private GameObject target;
        private GameManager _gameManager;

        [Inject]
        public void Construct(EnemyPool enemyPool, GameManager gameManager)
        {
            _gameManager = gameManager;
            _enemyPool = enemyPool;
        }

        private readonly HashSet<GameObject> _activeEnemies = new();

        public bool TrySpawnEnemy(out GameObject enemy)
        {
            if (!_enemyPool.TryGetEnemy(target, out enemy))
                return false;

            if (_activeEnemies.Add(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().OnHpEmpty += OnEnemyDestroyed;
                _gameManager.Register(enemy.GetComponent<EnemyAttackAgent>());
                _gameManager.Register(enemy.GetComponent<EnemyAIAgent>());
                _gameManager.Register(enemy.GetComponent<EnemyMoveAgent>());
            }

            return true;
        }

        private void OnEnemyDestroyed(GameObject enemy)
        {
            if (!_activeEnemies.Remove(enemy)) return;
            enemy.GetComponent<HitPointsComponent>().OnHpEmpty -= OnEnemyDestroyed;
            _enemyPool.Release(enemy);
        }
    }
}