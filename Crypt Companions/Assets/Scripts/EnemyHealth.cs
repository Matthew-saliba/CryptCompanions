using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 100;
    private int currentHealth;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
        Debug.Log("Enemy took damage: " + damage + ", Current Health: " + currentHealth);
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
