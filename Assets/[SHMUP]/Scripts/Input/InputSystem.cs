using System;
using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public sealed class InputSystem : IGameUpdateListener
    {
        public float HorizontalDirection { get; private set; }

        public event Action OnFire;

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