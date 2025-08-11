using UnityEngine;
public class PlayerHealth : Health
{
    [SerializeField] private int healFlask = 2; // Maximum times user can heal
    [SerializeField] private int healAmount = 20; // Amount to heal when using the healing item

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && healFlask > 0)
        {
            HealPlayer();
        }   
    }

    protected override void Die()
    {
        Debug.Log("Player died! Game over logic here.");
        // Add game over logic, respawn, etc.
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