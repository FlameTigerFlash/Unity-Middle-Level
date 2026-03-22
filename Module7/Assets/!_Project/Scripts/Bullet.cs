using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private Collider _collider;
    private Rigidbody _rb;
    private Renderer _renderer;

    private float _lifetimeAfterCollision = 0;

    private void Start()
    {
        _collider = GetComponent<Collider>();

        _renderer = GetComponent<Renderer>();

        _rb = GetComponent<Rigidbody>();
        _lifetimeAfterCollision = _particleSystem.main.duration;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision == null)
        {
            return;
        }

        _particleSystem.Play();
        _rb.linearVelocity = Vector3.zero;

        _collider.enabled = false;

        if (_renderer != null)
        {
            _renderer.enabled = false;
        }

        Destroy(gameObject, _lifetimeAfterCollision);
    }
}
