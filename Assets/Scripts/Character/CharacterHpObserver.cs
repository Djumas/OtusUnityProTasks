using UnityEngine;

namespace ShootEmUp
{
    public class CharacterHpObserver : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private HitPointsComponent _hitPointsComponent;
        
        private void Awake()
        {
            _hitPointsComponent.Init();
        }
        
        private void OnEnable()
        {
            _hitPointsComponent.OnHpEmpty += OnCharacterDeath;
        }

        private void OnDisable()
        {
            _hitPointsComponent.OnHpEmpty -= OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject _) => gameManager.FinishGame();
    }
}