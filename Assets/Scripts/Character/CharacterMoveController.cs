using UnityEngine;

namespace ShootEmUp
{
    public class CharacterMoveController : MonoBehaviour
    {
        [SerializeField] private MoveComponent moveComponent;
        [SerializeField] private InputSystem inputSystem;
        
        public void Update()
        {
            moveComponent.Move(inputSystem.HorizontalDirection);
        }
    }
}