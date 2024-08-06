using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ShootEmUp
{
    public class CharacterHpObserver : MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        [ShowInInspector, ReadOnly] private GameManager _gameManager;
        [SerializeField] private HitPointsComponent hitPointsComponent;

        [Inject]
        public void Construct(GameManager gameManager)
        {
            Debug.Log($"{name} Construct");
            _gameManager = gameManager;
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