using UnityEngine;

namespace ShootEmUp
{
    public class CharacterMoveController : MonoBehaviour, IGameUpdateListener
    {
        [SerializeField] private MoveComponent moveComponent;
        [SerializeField] private InputSystem inputSystem;

        private void Awake()
        {
            IGameListener.Register(this);
        }

        public void OnUpdateGame(float deltaTime)
        {
            moveComponent.Move(inputSystem.HorizontalDirection);
        }
    }
}