using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] private int damage = 20; // Damage dealt by melee attack
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy with melee!");
            
            // Implement damage logic here
            Enemy enemyHealth = other.GetComponent<Enemy>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            
        }
    }
}