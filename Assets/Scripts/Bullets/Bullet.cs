using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour, IGamePauseListener, IGameFinishListener, IGameResumeListener
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        public bool IsPlayer { get; set; }
        public int Damage { get; set; }

        [SerializeField] private Vector3 _storedVelocity;

        [SerializeField] private new Rigidbody2D rigidbody2D;

        [SerializeField] private SpriteRenderer spriteRenderer;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("BulletCollided");
            OnCollisionEntered?.Invoke(this, collision);

            if (!collision.gameObject.TryGetComponent(out TeamComponent team))
            {
                return;
            }

            if (IsPlayer == team.IsPlayer)
            {
                return;
            }

            if (collision.gameObject.TryGetComponent(out HitPointsComponent hitPoints))
            {
                hitPoints.TakeDamage(Damage);
            }
        }

        /*private void Awake()
        {
            IGameListener.Register(this);
        }*/

        public void OnPauseGame()
        {
            _storedVelocity = rigidbody2D.velocity;
            rigidbody2D.velocity = Vector2.zero;
        }

        public void OnResumeGame()
        {
            rigidbody2D.velocity = _storedVelocity;
        }

        public void OnFinishGame()
        {
            rigidbody2D.velocity = Vector2.zero;
        }

        public void SetVelocity(Vector2 velocity)
        {
            rigidbody2D.velocity = velocity;
        }

        public void SetPhysicsLayer(int physicsLayer)
        {
            gameObject.layer = physicsLayer;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }

        public void Reset()
        {
            rigidbody2D.velocity = Vector2.zero;
        }
    }
}