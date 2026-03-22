using UnityEngine;

public class VisibilityChanger : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void SetVisible()
    {
        _animator.SetBool("IsVisible", true);
    }

    public void SetInvisible()
    {
        _animator.SetBool("IsVisible", false);
    }
}
