using UnityEngine;
public class PlayerHealth : Health
{
    [SerializeField] private int healFlask; // Maximum times user can heal
    [SerializeField] private int healAmount; // Amount to heal when using the healing item

    private void Awake()
    {
        base.Awake();
        startingHealth = PlayerData.MaxHealth;
        PlayerData.CurrentHealth = startingHealth;
        currentHealth = PlayerData.CurrentHealth;
        healFlask = PlayerData.HealFlasks;
    }
    
    private void Update()
    {
         
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
}