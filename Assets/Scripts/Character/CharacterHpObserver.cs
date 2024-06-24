using UnityEngine;

namespace ShootEmUp
{
    public class CharacterHpObserver : MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private HitPointsComponent hitPointsComponent;

        private void Awake()
        {
            IGameListener.Register(this);
        }

        public void OnStartGame()
        {
            hitPointsComponent.Init();
            hitPointsComponent.OnHpEmpty += OnCharacterDeath;
        }

        public void OnFinishGame()
        {
            hitPointsComponent.OnHpEmpty -= OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject _) => gameManager.FinishGame();
    }
}