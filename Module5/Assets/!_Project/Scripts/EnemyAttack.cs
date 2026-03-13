using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour, IBehaviour
{
    [SerializeField] private GameObject _target;

    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackDamage;
    [SerializeField] private float _attackCooldown;

    private bool _canAttack;

    private void Start()
    {
        _canAttack = true;
    }

    public float Evaluate()
    {
        float distance = Vector3.Distance(gameObject.transform.position, _target.transform.position);
        return (distance < _attackRange?1:0);
    }
    public void Behave()
    {
        if (_canAttack && _target.TryGetComponent<ObjectHP>(out var hp))
        {
            Debug.Log("Enemy attacks");
            hp.TakeDamage(_attackDamage);
            _canAttack = false;
            StartCoroutine(Cooldown(_attackCooldown));
        }
    }

    private IEnumerator Cooldown(float delay)
    {
        yield return new WaitForSeconds(delay);
        _canAttack = true;
    }
}
