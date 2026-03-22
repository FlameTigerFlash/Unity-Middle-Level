using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ShootAbility _shootAbility;
    [SerializeField] private VisibilityChanger _visibilityChanger;
    public void OnAttack()
    {
        _shootAbility.TryShoot();
    }

    public void OnSetVisible(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            _visibilityChanger.SetVisible();
        }
    }

    public void OnSetInvisible(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            _visibilityChanger.SetInvisible();
        }
    }
}
