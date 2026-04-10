using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private float _force = 10f;

    public void Move(Vector2 direction)
    {
        Vector3 direction3D = new Vector3(direction.x, 0, direction.y).normalized;
        _rb.AddForce(direction3D * _force, ForceMode.Force);
    }

    public void Fly()
    {
        _rb.AddForce(Vector3.up * _force, ForceMode.Force);
    }
}
