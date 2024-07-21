using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public class DelayedGameStarter:MonoBehaviour
    {
        [SerializeField] private int startDelay = 3;
        private GameManager _gameManager;

        [Inject]
        public void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

 
        [Button]
        public void DelayedStartGame()
        {
            if (_gameManager.GameState == GameState.Off)
            {
                StartCoroutine(WaitAndStart());
            }
            else
            {
                Debug.Log("Game is not Off!");
            }
        }

        private IEnumerator WaitAndStart()
        {
            for (int i = 0; i < startDelay; i++)
            {
                Debug.Log($"Game starting in...{startDelay - i}");
                yield return new WaitForSeconds(1);
            }
            _gameManager.StartGame();
        }
    }
}