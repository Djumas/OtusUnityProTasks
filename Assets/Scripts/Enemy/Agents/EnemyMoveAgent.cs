using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour, IGameFixedUpdateListener
    {
        [SerializeField] private float moveTreshhold = 0.25f;
        [SerializeField] private MoveComponent moveComponent;
        public bool IsReached { get; private set; }

        private Vector2 _destination;

        private void Awake()
        {
            IGameListener.Register(this);
        }

        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            IsReached = false;
        }

        public void OnFixedUpdateGame(float fixedDeltaTime)
        {
            if (IsReached)
            {
                return;
            }

            var vector = _destination - (Vector2)transform.position;
            if (vector.sqrMagnitude <= moveTreshhold * moveTreshhold)
            {
                IsReached = true;
                return;
            }

            var direction = vector.normalized * fixedDeltaTime;
            moveComponent.MoveInstantly(direction);
        }
    }
}