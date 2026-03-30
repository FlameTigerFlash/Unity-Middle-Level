using UnityEngine;

public class ContactTrap : MonoBehaviour
{
    [SerializeField] private float _damage = 60f;

    private void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject;
        if (other.TryGetComponent<ObjectHP>(out var hp))
        {
            hp.ReceiveDamage(_damage);
        }
        Destroy(gameObject);
    }
}
