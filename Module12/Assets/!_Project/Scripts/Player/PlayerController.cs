using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ObjectMovement _movement;

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            _movement.SetDirection(Vector3.zero);
            return;
        }

        Vector2 inputDir = context.ReadValue<Vector2>();

        Vector3 trueDir = new Vector3(inputDir.x, 0, inputDir.y);

        _movement.SetDirection(trueDir);
    }
}
