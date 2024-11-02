using System;
using System.Collections;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class GameOverManager:MonoBehaviour
{
    [SerializeField] private int waitTime;
    [SerializeField] private AtomicObject Player;

    [SerializeField] private ZombieSpawnManager _zombieSpawnManager;

    private void Awake()
    {
        var isPlayerDeadVariable = Player.Get<AtomicVariable<bool>>(LifeAPI.IsDead);
        isPlayerDeadVariable.Subscribe(GameOver);
    }

    public void GameOver(bool isDead)
    {
        if (isDead)
        {
            _zombieSpawnManager.enabled = false;
            StartCoroutine(WaitAndRestart());        
        }
    }

    private IEnumerator WaitAndRestart()
    {
        Debug.Log("GameOver!");
        Debug.Log($"Waiting for {waitTime} seconds and restart...");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}