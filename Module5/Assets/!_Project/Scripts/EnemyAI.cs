using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private BehaviourManager _behaviourManager;

    [SerializeField] private float _delay = 0.5f;
    private void Start()
    {
        StartCoroutine(Cooldown(_delay));
    }

    private void MakeDecision()
    {
        _behaviourManager.MakeDecision();
        StartCoroutine(Cooldown(_delay));
    }

    private IEnumerator Cooldown(float delay)
    {
        yield return new WaitForSeconds(delay);
        MakeDecision();
    }
}
