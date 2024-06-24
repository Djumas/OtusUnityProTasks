using UnityEngine;

namespace ShootEmUp
{
    public class EnemyAIAgent : MonoBehaviour, IGameFixedUpdateListener
    {
        [SerializeField] private EnemyMoveAgent moveAgent;
        [SerializeField] private EnemyAttackAgent attackAgent;
        [SerializeField] private HitPointsComponent hitPointsComponent;

        private void Awake()
        {
            attackAgent.SetActive(false);
            IGameListener.Register(this);
        }

        public void OnFixedUpdateGame(float deltaTime)
        {
            if (!moveAgent.IsReached)
            {
                return;
            }

            if (!hitPointsComponent.IsHitPointsExists())
            {
                attackAgent.SetActive(false);
                return;
            }

            if (!attackAgent.IsActive)
            {
                Debug.Log("Enemy activated");
                attackAgent.SetActive(true);
            }
        }
    }
}