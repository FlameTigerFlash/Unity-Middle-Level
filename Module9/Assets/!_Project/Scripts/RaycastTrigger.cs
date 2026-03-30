using DG.Tweening;
using UnityEngine;

public class RaycastTrigger : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;

    [SerializeField] private float _detectionDistance = 1f;
    [SerializeField] private float _movementDistance = 1f;
    [SerializeField] private float _movementTime = 5f;

    private Ray _ray;

    private bool _hasTriggered = false;

    private void Start()
    {
        _hasTriggered = false;
        _ray = new Ray(_startPoint.position, -transform.up * _detectionDistance);
        Debug.DrawRay(_startPoint.position, -transform.up * _detectionDistance, Color.red);
    }

    private void FixedUpdate()
    {
        if (!_hasTriggered && Physics.Raycast(_ray, out var hit, _detectionDistance))
        {
            _hasTriggered = true;
            transform.DOMove(_startPoint.position - transform.up * _movementDistance, _movementTime);
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(_startPoint.position, -transform.up * _detectionDistance, Color.red);
    }
}
