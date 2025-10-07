using UnityEngine;

public abstract class ShopTile : MonoBehaviour
{
    [SerializeField] protected int itemCost;

    private bool playerInRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void OnInteract()
    {
        if (playerInRange)
        {
            TryPurchase();
        }
    }

    protected abstract void TryPurchase();
}
