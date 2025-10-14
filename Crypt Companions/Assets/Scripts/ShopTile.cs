using UnityEngine;

public abstract class ShopTile : MonoBehaviour, IInteractable
{
    [SerializeField] protected int itemCost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // CHANGED: Tell the player this shop can be interacted with
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.SetCurrentInteractable(this);
                Debug.Log($"Entered {GetType().Name}. Press Interact to buy!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.ClearCurrentInteractable(this);
            }
        }
    }
    
    public void Interact(Player player)
    {
        TryPurchase(player);
    }
    
    protected abstract void TryPurchase(Player player);
}