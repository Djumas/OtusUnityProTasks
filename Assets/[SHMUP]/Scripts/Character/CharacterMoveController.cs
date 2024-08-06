using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public class CharacterMoveController : MonoBehaviour, IGameUpdateListener
    {
        [SerializeField] private MoveComponent moveComponent;
        [ShowInInspector, ReadOnly] private InputSystem _inputSystem;

        [Inject]
        public void Construct(InputSystem inputSystem, GameManager gameManager)
        {
            Debug.Log($"{name} Construct");
            _inputSystem = inputSystem;
        }

        public void OnUpdateGame(float deltaTime)
        {
            moveComponent.Move(_inputSystem.HorizontalDirection);
        }
    }
}