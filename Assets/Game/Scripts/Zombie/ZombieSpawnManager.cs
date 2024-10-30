using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZombieSpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform container;
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private float spawnCoolDown;
    [SerializeField, ReadOnly] private float spawnCoolDownLeft;

    private void Awake()
    {
        spawnCoolDownLeft = spawnCoolDown;
    }

    private void Update()
    {
        spawnCoolDownLeft -= Time.deltaTime;
        if (spawnCoolDownLeft <= 0)
        {
            spawnCoolDownLeft = spawnCoolDown;
            var sampledPointNumber = Random.Range(0, spawnPoints.Length);
            Instantiate(zombiePrefab, spawnPoints[sampledPointNumber].position, spawnPoints[sampledPointNumber].rotation);
        }
    }
}