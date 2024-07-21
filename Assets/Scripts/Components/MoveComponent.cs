using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public sealed class MoveComponent : MonoBehaviour, IGameFixedUpdateListener
    {
        [SerializeField] private new Rigidbody2D rigidbody2D;

        [SerializeField] private float speed = 5.0f;

        private float horizontalDirection;

        [Inject]
        public void Construct(GameManager gameManager)
        {
            Debug.Log($"{name} Construct");
        }

        public void Move(float horizontalDirection)
        {
            this.horizontalDirection = horizontalDirection;
        }

        public void MoveInstantly(Vector2 vector)
        {
            MoveByRigidbodyVelocity(vector);
        }

        private void MoveByRigidbodyVelocity(Vector2 vector)
        {
            var nextPosition = rigidbody2D.position + vector * speed;
            rigidbody2D.MovePosition(nextPosition);
        }

        public void OnFixedUpdateGame(float fixedDeltaTime)
        {
            MoveByRigidbodyVelocity(new Vector2(horizontalDirection, 0) * fixedDeltaTime);
        }
    }
}