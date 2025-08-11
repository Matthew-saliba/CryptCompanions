using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int startingHealth = 100;
    protected int currentHealth;

    protected virtual void Awake()
    {
        currentHealth = startingHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
        Debug.Log(gameObject.name + " took damage: " + damage + ", Current Health: " + currentHealth);
    }

    protected virtual void Die()
    {
        // Default behavior for death , ovverride in derived classes
        Debug.Log(gameObject.name + " died!");
    }
}