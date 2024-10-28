using Atomic.Extensions;
using Atomic.Objects;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveInputController : MonoBehaviour
{
    [SerializeField] private AtomicEntity player;
    [SerializeField] private Camera mCamera;
    [SerializeField] private Transform root;
    [SerializeField, ReadOnly] private Vector3 moveDirection;
    [SerializeField, ReadOnly] private Vector3 rotationDirection;

    private void Update()
    {
        HandleKeyboardInput();
        HandleMouseInput();
    }

    private void HandleKeyboardInput()
    {
        moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) moveDirection += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) moveDirection += Vector3.back;
        if (Input.GetKey(KeyCode.D)) moveDirection += Vector3.right;
        if (Input.GetKey(KeyCode.A)) moveDirection += Vector3.left;

        player.GetVariable<Vector3>(MoveAPI.MoveDirection).Value = moveDirection;
    }

    private void HandleMouseInput()
    {
        var ray = mCamera.ScreenPointToRay(Input.mousePosition);
        var plane = new Plane(Vector3.up, root.position);
        plane.Raycast(ray, out var point);
        rotationDirection = ray.GetPoint(point) - root.position;

        player.GetVariable<Vector3>(MoveAPI.RotationDirection).Value = rotationDirection;
    }
}