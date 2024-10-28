using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

public class ShootInputController : MonoBehaviour
{
    [SerializeField] private AtomicEntity player;

    private void Update()
    {
        HandleMouseInput();
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("ShootMouseDown");
            var shootRequest = player.Get<AtomicEvent>(ShootAPI.ShootRequest);
            //Debug.Log(shootRequest);
            shootRequest.Invoke();
        }
    }
}
