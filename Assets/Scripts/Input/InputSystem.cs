using System;
using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public sealed class InputSystem : IGameUpdateListener
    {
        public float HorizontalDirection { get; private set; }

        public event Action OnFire;

        [Inject]
        public void Construct(GameManager gameManager)
        {
            gameManager.Register(this);
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