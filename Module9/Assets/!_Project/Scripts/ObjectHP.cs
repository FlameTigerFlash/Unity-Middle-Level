using UnityEngine;
using UnityEngine.Events;

public class ObjectHP : MonoBehaviour
{
    [SerializeField] private float _hp = 100;

    public UnityEvent<bool> ReceiveDamageEvent;

    public float HP => _hp;

    public void ReceiveDamage(float damage)
    {
        _hp -= Mathf.Abs(damage);
        ReceiveDamageEvent.Invoke(_hp <= 0);
    }
}
