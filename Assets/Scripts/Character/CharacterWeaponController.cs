using Unity.VisualScripting;
using UnityEditor.AddressableAssets.Build;
using UnityEngine;

namespace ShootEmUp
{
    public class CharacterWeaponController : MonoBehaviour
    {
        [SerializeField] private WeaponComponent weaponComponent;
        [SerializeField] private InputSystem inputSystem;

        private void OnEnable()
        {
            inputSystem.OnFire += Fire;
        }

        private void OnDisable() {
            inputSystem.OnFire -= Fire;
        }

        private void Fire()
        {
            weaponComponent.Fire();
        }

    }
}