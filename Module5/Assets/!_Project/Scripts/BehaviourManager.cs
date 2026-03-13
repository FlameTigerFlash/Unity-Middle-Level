using UnityEngine;
using System.Collections.Generic;

public class BehaviourManager : MonoBehaviour
{
    [SerializeField] private List<MonoBehaviour> _behaviours;

    private IBehaviour _activeBehaviour;

    private void Start()
    {
        foreach (var behaviour in _behaviours)
        {
            if (behaviour is not IBehaviour)
            {
                _behaviours.Remove(behaviour);
            }
        }
    }

    private void Update()
    {
        if (_activeBehaviour is not null)
        {
            _activeBehaviour.Behave();
        }
    }

    public void MakeDecision()
    {
        float maxVal = 0;
        foreach (var el in _behaviours)
        {
            IBehaviour behaviour = el as IBehaviour;
            float curVal = behaviour.Evaluate();
            if (curVal > maxVal)
            {
                maxVal = curVal;
                _activeBehaviour = behaviour;
            }
        }
    }
}
