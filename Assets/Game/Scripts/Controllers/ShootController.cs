using System.Collections;
using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using Sirenix.OdinInspector;
using UnityEngine;

public class ShootController : MonoBehaviour
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
