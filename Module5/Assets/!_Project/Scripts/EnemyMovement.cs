using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour, IBehaviour
{
    [SerializeField] private GameObject _target;

    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public float Evaluate()
    {
        float distance = Vector3.Distance(gameObject.transform.position, _target.transform.position);
        return Mathf.Clamp(distance, 0, 10) / 10;
    }
    public void Behave()
    {
        _agent.destination = _target.transform.position;
    }
}
