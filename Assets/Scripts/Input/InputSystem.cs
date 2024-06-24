using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputSystem : MonoBehaviour, IGameUpdateListener
    {
        public float HorizontalDirection { get; private set; }

        public event Action OnFire;

        private void Awake()
        {
            IGameListener.Register(this);
        }

        public void OnUpdateGame(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFire?.Invoke();
            }

            HorizontalDirection = Input.GetAxisRaw("Horizontal");
        }
    }
}