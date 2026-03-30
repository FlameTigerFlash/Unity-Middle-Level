using System.Collections;
using UnityEngine;

public class ShootAbility : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;

    [SerializeField] private float _projectileSpeed= 1f;
    [SerializeField] private float _cooldown = 1f;

    private bool _canShoot = true;

    public void TryShoot()
    {
        if (_canShoot)
        {
            _canShoot = false;
            Shoot();
            StartCoroutine(Cooldown(_cooldown));
        }
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(_projectilePrefab, transform.position, transform.rotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        projectileRb.AddRelativeForce(Vector3.forward * _projectileSpeed, ForceMode.VelocityChange);
    }

    private IEnumerator Cooldown(float delay)
    {
        yield return new WaitForSeconds(delay);
        _canShoot = true;
    }
}
