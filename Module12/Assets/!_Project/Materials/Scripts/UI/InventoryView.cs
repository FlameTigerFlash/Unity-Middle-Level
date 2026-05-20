using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryView;

    [SerializeField] private Button _inventoryButton;

    public void ShowInventory()
    {
        _inventoryView.SetActive(true);
        _inventoryButton.gameObject.SetActive(false);
    }

    public void HideInventory()
    {
        _inventoryView.SetActive(false);
        _inventoryButton.gameObject.SetActive(true);
    }
}
