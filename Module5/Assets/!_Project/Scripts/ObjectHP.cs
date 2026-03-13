using UnityEngine;

public class ObjectHP : MonoBehaviour
{
    [SerializeField] private float _hp = 100;

    public void TakeDamage(float damage)
    {
        _hp -= Mathf.Abs(damage);
        Debug.Log("Damage taken!!!");
    }
}
