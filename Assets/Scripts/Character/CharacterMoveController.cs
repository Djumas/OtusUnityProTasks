using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public class CharacterMoveController : MonoBehaviour, IGameUpdateListener
    {
        [SerializeField] private MoveComponent moveComponent;
        private InputSystem _inputSystem;

        [Inject]
        public void Construct(InputSystem inputSystem, GameManager gameManager)
        {
            _inputSystem = inputSystem;
            gameManager.Register(this);
        }

        public void OnUpdateGame(float deltaTime)
        {
            moveComponent.Move(_inputSystem.HorizontalDirection);
        }
    }
}