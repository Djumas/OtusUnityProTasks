using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public class EnemyCoolDownSpawner : MonoBehaviour, IGameUpdateListener
    {
        private EnemySpawnController _enemySpawnController;
        [SerializeField] private float spawnCoolDown = 1f;
        private float _elapsedTime = 0;

        [Inject]
        public void Construct(EnemySpawnController enemySpawnController, GameManager gameManager)
        {
            _enemySpawnController = enemySpawnController;
            gameManager.Register(this);
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