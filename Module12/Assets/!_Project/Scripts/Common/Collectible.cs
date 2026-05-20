using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private GameObject _collectible;

    private void OnTriggerEnter(Collider other)
    {
        if (_collectible == null)
        {
            Debug.LogWarning("Collectible game object not set.");
            return;
        }
        if (_collectible.CompareTag("InventoryItem") == false)
        {
            Debug.LogWarning("Incorrect collectible object.");
            return;
        }
        Inventory inventory = other.GetComponent<Inventory>();

        if (inventory != null)
        {
            inventory.AddItem(_collectible);
        }
        Destroy(gameObject);
    }
}
