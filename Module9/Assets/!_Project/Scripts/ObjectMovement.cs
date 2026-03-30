using UnityEngine;
using UnityEngine.Rendering;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;

    public float Speed => _speed;

    private Rigidbody _rb;

    private void Start()
    {
        Setup();
    }

    public void Setup()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        _rb.linearVelocity = direction * _speed;
        if (direction != Vector3.zero)
        {
            _rb.rotation = Quaternion.LookRotation(direction);
        }
    }

    public void Stop()
    {
        _rb.linearVelocity = Vector3.zero;
    }
}
