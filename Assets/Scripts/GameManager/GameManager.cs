using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;
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
        public GameState GameState { get; private set; } = GameState.Off;

        [ShowInInspector, ReadOnly] private IEnumerable<IGameListener> _gameListenersEnumerable;

        [ShowInInspector, ReadOnly] private List<IGameListener> _gameListeners = new();
        [ShowInInspector, ReadOnly] private List<IGameUpdateListener> _gameUpdateListeners = new();
        [ShowInInspector, ReadOnly] private List<IGameFixedUpdateListener> _gameFixedUpdateListeners = new();

        private IObjectResolver _resolver;

        [Inject]
        public void Construct(IObjectResolver resolver)
        {
            _resolver = resolver;
        }

        private void Awake()
        {
            Debug.Log($"{name} is trying to Inject");

            _gameListenersEnumerable = _resolver.Resolve<IEnumerable<IGameListener>>();

            foreach (var gameListenerEnumerable in _gameListenersEnumerable)
            {
                _gameListeners.Add(gameListenerEnumerable);
            }

            Debug.Log($"GameListeners Count: {_gameListeners.Count}");

            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGameUpdateListener gameUpdateListener)
                {
                    _gameUpdateListeners.Add(gameUpdateListener);
                }

                if (gameListener is IGameFixedUpdateListener gameFixedUpdateListener)
                {
                    _gameFixedUpdateListeners.Add(gameFixedUpdateListener);
                }
            }
        }

        public void Register(IGameListener gameListener)
        {
            Debug.Log($"GameManager.register is called by {gameListener}");
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
            GameState = GameState.Off;
        }

        [Button]
        public void StartGame()
        {
            if (GameState != GameState.Off)
            {
                Debug.Log("Game is not off");
                return;
            }

            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGameStartListener gameFinishListener)
                {
                    gameFinishListener.OnStartGame();
                }
            }

            GameState = GameState.Playing;
            Debug.Log("Game started!");
        }

        [Button]
        public void PauseGame()
        {
            if (GameState != GameState.Playing)
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

            GameState = GameState.Pause;
        }

        [Button]
        public void ResumeGame()
        {
            if (GameState != GameState.Pause)
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

            GameState = GameState.Playing;
        }

        [Button]
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

            GameState = GameState.Finish;
        }

        public void Tick()
        {
            if (GameState == GameState.Playing)
            {
                foreach (var gameUpdateListener in _gameUpdateListeners)
                {
                    gameUpdateListener.OnUpdateGame(Time.deltaTime);
                }
            }
        }

        public void FixedTick()
        {
            if (GameState == GameState.Playing)
            {
                foreach (var gameFixedUpdateListener in _gameFixedUpdateListeners)
                {
                    gameFixedUpdateListener.OnFixedUpdateGame(Time.fixedDeltaTime);
                }
            }
        }
    }
}