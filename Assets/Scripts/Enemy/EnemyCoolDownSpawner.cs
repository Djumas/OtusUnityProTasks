using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public class EnemyCoolDownSpawner : MonoBehaviour
    {
        [SerializeField] private EnemySpawnController enemySpawnController;

        [SerializeField] private float spawnCoolDown = 1f;
        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnCoolDown);
                enemySpawnController.TrySpawnEnemy(out GameObject _);
            }
        }
    }
}