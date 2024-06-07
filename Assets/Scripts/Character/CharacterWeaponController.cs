using UnityEngine;

namespace ShootEmUp
{
    public class CharacterWeaponController : MonoBehaviour, IGamePauseListener,IGameResumeListener, IGameStartListener, IGameFinishListener
    {
        [SerializeField] private WeaponComponent weaponComponent;
        [SerializeField] private InputSystem inputSystem;

        private void Awake()
        {
            IGameListener.Register(this);
        }
        
        public void OnPauseGame()
        {
            inputSystem.OnFire -= Fire;
        }

        public void OnResumeGame()
        {
            inputSystem.OnFire += Fire;
        }

        public void OnStartGame()
        {
            inputSystem.OnFire += Fire;
        }

        public void OnFinishGame()
        {
            inputSystem.OnFire -= Fire;
        }
        
        private void Fire()
        {
            weaponComponent.Fire();
        }
    }
}