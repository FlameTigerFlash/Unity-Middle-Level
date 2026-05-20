using NUnit.Framework;
using UnityEngine;

using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform _inventoryBox;

    private List<BasePerk> _perks = new List<BasePerk>();

    private void Start()
    {
        Setup();
    }

    public void AddItem(GameObject item)
    {
        if (item.TryGetComponent<BasePerk>(out var perk) && _perks.Contains(perk))
        {
            return;
        }
        _perks.Add(perk);
        var obj = Instantiate(item, _inventoryBox);
        obj.gameObject.GetComponent<InventoryItemSetup>().SetOwner(gameObject);
    }

    public void DeleteItem(GameObject item)
    {
        if (item.TryGetComponent<BasePerk>(out var perk) && _perks.Contains(perk))
        {
            _perks.Remove(perk);
        }
        Destroy(item);
    }

    private void Setup()
    {
        if (_inventoryBox == null)
        {
            return;
        }
        foreach (Transform obj in _inventoryBox)
        {
            obj.gameObject.GetComponent<InventoryItemSetup>().SetOwner(gameObject);
        }
    }
}
