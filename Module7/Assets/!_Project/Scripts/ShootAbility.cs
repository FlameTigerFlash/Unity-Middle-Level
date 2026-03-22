using System.Collections;
using UnityEditor;
using UnityEngine;

public class ShootAbility : MonoBehaviour
{
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] private float _projectileSpeed = 5.0f;
    [SerializeField] private float _cooldown = 0.3f;

    private bool _canShoot = true;

    public void TryShoot()
    {
        if (_canShoot)
        {
            ShootBullet();
            StartCoroutine(Cooldown(_cooldown));
        }
    }

    private void ShootBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _shootingPoint.position, _shootingPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        rb.linearVelocity = _projectileSpeed * _shootingPoint.forward;
    }

    private IEnumerator Cooldown(float delay)
    {
        _canShoot = false;
        yield return new WaitForSeconds(delay);
        _canShoot = true;
    }
}
