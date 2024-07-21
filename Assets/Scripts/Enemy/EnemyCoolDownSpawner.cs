using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public class EnemyCoolDownSpawner : MonoBehaviour, IGameUpdateListener
    {
        [ShowInInspector, ReadOnly] private EnemySpawnController _enemySpawnController;
        [SerializeField] private float spawnCoolDown = 1f;
        private float _elapsedTime = 0;

        [Inject]
        public void Construct(EnemySpawnController enemySpawnController)
        {
            Debug.Log($"{name} Construct");
            _enemySpawnController = enemySpawnController;
        }
        
        public void OnUpdateGame(float deltaTime)
        {
            {
                _elapsedTime += deltaTime;

                if (_elapsedTime >= spawnCoolDown)
                {
                    Debug.Log("Trying to spawn");
                    _enemySpawnController.TrySpawnEnemy(out GameObject _);
                    _elapsedTime = 0;
                }
            }
        }
    }
}