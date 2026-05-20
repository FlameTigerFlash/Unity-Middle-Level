using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSetup : MonoBehaviour
{
    [SerializeField] private BaseUtility _utility;

    [SerializeField] private Button _button;

    private GameObject _target;

    private void Awake()
    {

        if (_utility == null)
        {
            _button.enabled = false;
        }
        else
        {
            _button.enabled = true;
        }
    }

    public void OnExecute()
    {
        if (_utility == null)
        {
            return;
        }

        _utility.Execute(_target);
    }

    public void SetOwner(GameObject target)
    {
        _target = target;
    }
}
