using UnityEngine;
public class Player : Health
{
    [SerializeField] private int healFlask; // Maximum times user can heal
    [SerializeField] private int healAmount; // Amount to heal when using the healing item
    [SerializeField] private int gold;
    
    private IInteractable currentInteractable;

    private void Awake()
    {
        base.Awake();
        startingHealth = PlayerData.MaxHealth;
        PlayerData.CurrentHealth = startingHealth;
        currentHealth = PlayerData.CurrentHealth;
        healFlask = PlayerData.HealFlasks;
        gold = PlayerData.CurrentGold;
    }
    
    private void Update()
    {
         
    }
    
    void OnInteract()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact(this);
        }
        else
        {
            Debug.Log("Nothing to interact with!");
        }
    }

    void OnFlask()
    {
        if (healFlask > 0)
        {
            HealPlayer();
        }  
    }

    protected override void Die()
    {
        Debug.Log("Player died! Game over logic here.");
        // Add game over logic, respawn, etc.
        //For temporary purposes, we can just destroy the player object
        Destroy(this.gameObject);
    }

    private void HealPlayer()
    {
        currentHealth += healAmount;
        if(currentHealth > startingHealth)
        {
            currentHealth = startingHealth; // Ensure health does not exceed starting health
        }
        healFlask--;
        Debug.Log("Healed! Current Health: " + currentHealth + ", Flasks remaining: " + healFlask);
    }
    
    public void AddGold(int amount)
    {
        gold += amount;
    }
    
    public void AddFlask(int amount)
    {
        healFlask += amount;
    }
    
    public int GetGold()
    {
        return gold;
    }
    
    public int GetFlask()
    {
        return healFlask;
    }
    
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    
    
    public void SetCurrentInteractable(IInteractable interactable)
    {
        currentInteractable = interactable;
    }
    
    public void ClearCurrentInteractable(IInteractable interactable)
    {
        if (currentInteractable == interactable)
        {
            currentInteractable = null;
        }
    }
}