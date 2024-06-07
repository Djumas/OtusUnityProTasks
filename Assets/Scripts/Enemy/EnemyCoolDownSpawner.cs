using System;
using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemyCoolDownSpawner : MonoBehaviour, IGameUpdateListener
    {
        [SerializeField] private EnemySpawnController enemySpawnController;
        [SerializeField] private float spawnCoolDown = 1f;
        private float _elapsedTime = 0;

        private void Awake()
        {
            IGameListener.Register(this);
        }

        public void OnUpdateGame(float deltaTime)
        {
            {
                _elapsedTime += deltaTime;

                if (_elapsedTime >= spawnCoolDown)
                {
                    Debug.Log("Trying to spawn");
                    enemySpawnController.TrySpawnEnemy(out GameObject _);
                    _elapsedTime = 0;
                }
            }
        }
    }
}