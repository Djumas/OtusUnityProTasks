using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerManager : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameManager gameManager;
        private MoveComponent _moveComponent;
        private WeaponComponent _weaponComponent;
        private HitPointsComponent _hitPointsComponent;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _moveComponent = player.GetComponent<MoveComponent>();
            _weaponComponent = player.GetComponent<WeaponComponent>();
            _hitPointsComponent = player.GetComponent<HitPointsComponent>();
            _hitPointsComponent.Init();
        }

        private void OnEnable()
        {
            _hitPointsComponent.hpEmpty += this.OnCharacterDeath;
        }

        private void OnDisable()
        {
            _hitPointsComponent.hpEmpty -= this.OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject _) => this.gameManager.FinishGame();


        public void Move(float horizontalDirection)
        {
            _moveComponent.Move(horizontalDirection);
        }


        public void Fire()
        {
            _weaponComponent.Fire();
        }
    }
}