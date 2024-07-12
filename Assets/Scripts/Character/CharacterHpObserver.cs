using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ShootEmUp
{
    public class CharacterHpObserver : MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        private GameManager _gameManager;
        [SerializeField] private HitPointsComponent hitPointsComponent;

        [Inject]
        public void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
            _gameManager.Register(this);
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

        private void OnCharacterDeath(GameObject _) => _gameManager.FinishGame();
    }
}