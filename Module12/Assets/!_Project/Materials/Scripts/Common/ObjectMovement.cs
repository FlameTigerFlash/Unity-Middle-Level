using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private float _speed = 5f;

    public float Speed => _speed;

    private Vector3 _direction;

    public void FixedUpdate()
    {
        _rb.linearVelocity = new Vector3(_direction.x * _speed, _rb.linearVelocity.y, _direction.z * _speed);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
}
