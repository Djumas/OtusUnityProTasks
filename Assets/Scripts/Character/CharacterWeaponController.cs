using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public class CharacterWeaponController : MonoBehaviour, IGamePauseListener, IGameResumeListener, IGameStartListener,
        IGameFinishListener
    {
        [SerializeField] private WeaponComponent weaponComponent;
        private InputSystem _inputSystem;

        
        [Inject]
        public void Construct(InputSystem inputSystem)
        {
            _inputSystem = inputSystem;
        }
        
        
        private void Awake()
        {
            IGameListener.Register(this);
        }

        public void OnPauseGame()
        {
            _inputSystem.OnFire -= Fire;
        }

        public void OnResumeGame()
        {
            _inputSystem.OnFire += Fire;
        }

        public void OnStartGame()
        {
            _inputSystem.OnFire += Fire;
        }

        public void OnFinishGame()
        {
            _inputSystem.OnFire -= Fire;
        }

        private void Fire()
        {
            weaponComponent.Fire();
        }
    }
}