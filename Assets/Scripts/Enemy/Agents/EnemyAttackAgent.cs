using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour, IGameFixedUpdateListener
    {
        [SerializeField] private WeaponComponent weaponComponent;
        [SerializeField] private float countdown;

        private GameObject _target;
        private float _currentTime;
        public bool IsActive { get; private set; }

        private void Awake()
        {
            IGameListener.Register(this);
        }

        public void SetActive(bool state)
        {
            IsActive = state;
        }

        public void SetTarget(GameObject target)
        {
            this._target = target;
        }

        public void Reset()
        {
            _currentTime = countdown;
        }

        public void OnFixedUpdateGame(float fixedDeltaTime)
        {
            if (IsActive)
            {
                _currentTime -= fixedDeltaTime;
                if (_currentTime <= 0)
                {
                    Fire();
                    _currentTime += countdown;
                }
            }
        }

        private void Fire()
        {
            weaponComponent.Fire(_target.transform.position, false);
        }
    }
}