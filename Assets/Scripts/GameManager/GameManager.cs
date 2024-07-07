using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace ShootEmUp
{
    public enum GameState
    {
        Playing,
        Finish,
        Pause,
        Off
    }

    public sealed class GameManager : MonoBehaviour, ITickable, IFixedTickable
    {
        [SerializeField] private int startDelay = 3;

        private static List<IGameListener> _gameListeners = new();
        private static List<IGameUpdateListener> _gameUpdateListeners = new();
        private static List<IGameFixedUpdateListener> _gameFixedUpdateListeners = new();

        private GameState _gameState = GameState.Off;

        public static void Register(IGameListener gameListener)
        {
            _gameListeners.Add(gameListener);

            if (gameListener is IGameUpdateListener gameUpdateListener)
            {
                _gameUpdateListeners.Add(gameUpdateListener);
            }

            if (gameListener is IGameFixedUpdateListener gameFixedUpdateListener)
            {
                _gameFixedUpdateListeners.Add(gameFixedUpdateListener);
            }
        }

        private void OnDestroy()
        {
            _gameState = GameState.Off;
        }

        public void FinishGame()
        {
            Debug.Log("Game over!");

            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGameFinishListener gameFinishListener)
                {
                    gameFinishListener.OnFinishGame();
                }
            }

            _gameState = GameState.Finish;
        }

        public void StartGame()
        {
            if (_gameState != GameState.Off)
            {
                Debug.Log("Game is not off");
                return;
            }

            StartCoroutine(WaitAndStart());
        }

        private IEnumerator WaitAndStart()
        {
            for (int i = 0; i < startDelay; i++)
            {
                Debug.Log($"Game starting in...{startDelay - i}");
                yield return new WaitForSeconds(1);
            }

            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGameStartListener gameFinishListener)
                {
                    gameFinishListener.OnStartGame();
                }
            }

            _gameState = GameState.Playing;
            Debug.Log("Game started!");
        }


        public void PauseGame()
        {
            if (_gameState != GameState.Playing)
            {
                Debug.Log("Game is not playing!");
                return;
            }

            Debug.Log("Game paused!");

            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGamePauseListener gameFinishListener)
                {
                    gameFinishListener.OnPauseGame();
                }
            }

            _gameState = GameState.Pause;
        }

        public void ResumeGame()
        {
            if (_gameState != GameState.Pause)
            {
                Debug.Log("Game not paused!");
                return;
            }

            Debug.Log("Game resumed!");

            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGameResumeListener gameFinishListener)
                {
                    gameFinishListener.OnResumeGame();
                }
            }

            _gameState = GameState.Playing;
        }

        public void Tick()
        {
            if (_gameState == GameState.Playing)
            {
                foreach (var gameUpdateListener in _gameUpdateListeners)
                {
                    gameUpdateListener.OnUpdateGame(Time.deltaTime);
                }
            }
        }

        public void FixedTick()
        {
            if (_gameState == GameState.Playing)
            {
                foreach (var gameFixedUpdateListener in _gameFixedUpdateListeners)
                {
                    gameFixedUpdateListener.OnFixedUpdateGame(Time.fixedDeltaTime);
                }
            }
        }
    }
}