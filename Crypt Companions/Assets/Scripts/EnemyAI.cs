using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private int damage = 10; // Damage dealt to player when attacking
    
    private Transform player;
    private float distanceToPlayer;
    
    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        
        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the player has the 'Player' tag.");
        }
        
    }
    
    private void Update()
    {
        if (player != null)
        {
            // Calculate distance
            distanceToPlayer = Vector3.Distance(transform.position, player.position);
            
            // Move toward player if in detection range but not in attack range 
            if (distanceToPlayer <= detectionRange && distanceToPlayer > attackRange)
            {
                MoveTowardsPlayer();
            }
            // Attack if in attack range
            else if (distanceToPlayer <= attackRange)
            {
                AttackPlayer();
            }
            
        }
    }
    
    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        
        //Rotate to face the player
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    
    private void AttackPlayer()
    {
        // Implement attack logic here, e.g., deal damage to player
        Debug.Log("Enemy attacks the player!");
        // You can call a method on the player's health script to apply damage
        player.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
}
