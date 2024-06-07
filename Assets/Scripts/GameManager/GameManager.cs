using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

namespace ShootEmUp
{
    public enum GameState
    {
        Playing,
        Finish,
        Pause,
        Off
    }

    public sealed class GameManager : MonoBehaviour
    {
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
            
            Debug.Log("Game started!");

            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGameStartListener gameFinishListener)
                {
                    gameFinishListener.OnStartGame();
                }
            }
            
            _gameState = GameState.Playing;
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

        private void Update()
        {
            if (_gameState == GameState.Playing)
            {
                foreach (var gameUpdateListener in _gameUpdateListeners)
                {
                    gameUpdateListener.OnUpdateGame(Time.deltaTime);
                }
            }
        }
        
        private void FixedUpdate()
        {
            if (_gameState == GameState.Playing)
            {
                foreach (var gameFixedUpdateListener in _gameFixedUpdateListeners)
                {
                    gameFixedUpdateListener.OnFixedUpdateGame(Time.fixedDeltaTime);
                }
            }
        }

#if UNITY_EDITOR
        void OnGUI()
        {
            if (GUILayout.Button("Start Game"))
            {
                StartGame();
            }
            
            if (GUILayout.Button("Finish Game"))
            {
                FinishGame();
            }
            
            if (GUILayout.Button("Pause Game"))
            {
                PauseGame();
            }
            
            if (GUILayout.Button("Resume Game"))
            {
                ResumeGame();
            }
        }
#endif
    }
    
[CustomEditor(typeof(GameManager))]
    public class GameManagerEditor:Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var targ = (GameManager)target;
            
            if (GUILayout.Button("Start game"))
            {
                targ.StartGame();
            }
            
            if (GUILayout.Button("Pause game"))
            {
                targ.PauseGame();
            }
            
            if (GUILayout.Button("Resume game"))
            {
                targ.ResumeGame();
            }
            
            if (GUILayout.Button("Finish game"))
            {
                targ.FinishGame();
            }
        }
    }
}