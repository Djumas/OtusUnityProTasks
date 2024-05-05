using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        private float _horizontalDirection;

        [SerializeField] private PlayerManager playerManager;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerManager.Fire();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _horizontalDirection = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                _horizontalDirection = 1;
            }
            else
            {
                _horizontalDirection = 0;
            }

            playerManager.Move(_horizontalDirection);
        }
    }
}