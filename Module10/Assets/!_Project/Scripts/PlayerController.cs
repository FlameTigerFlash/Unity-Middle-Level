using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ObjectMove _objectMove;

    private Vector2 _direction;

    private bool _isFlying = false;

    private void Awake()
    {
        _isFlying = false;
    }

    private void FixedUpdate()
    {
        if (_isFlying)
        {
            _objectMove.Fly();
        }
        _objectMove.Move(_direction);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _direction = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            _direction = Vector2.zero;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _isFlying = true;
        }
        else if (context.canceled)
        {
            _isFlying = false;
        }
    }
}
