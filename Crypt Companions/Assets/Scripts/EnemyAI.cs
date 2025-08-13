using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Detection")]
    [SerializeField] protected float detectionRange = 10f;
    [SerializeField] protected float attackRange = 2f;
    
    [Header("Movement")]
    [SerializeField] protected float moveSpeed = 3f;
    
    [Header("Combat")]
    [SerializeField] protected float attackCooldown = 1.5f;
    [SerializeField] protected int attackDamage = 10;
    
    protected Transform player;
    protected float distanceToPlayer;
    protected bool canAttack = true;
    
    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        
        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the player has the 'Player' tag.");
        }
    }
    
    protected virtual void Update()
    {
        if (player != null)
        {
            distanceToPlayer = Vector3.Distance(transform.position, player.position);
            
            if (distanceToPlayer <= detectionRange && distanceToPlayer > attackRange)
            {
                MoveTowardsPlayer();
            }
            else if (distanceToPlayer <= attackRange && canAttack)
            {
                StartCoroutine(PerformAttack());
            }
        }
    }
    
    protected virtual void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        
        // Rotate to face the player
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    
    protected virtual IEnumerator PerformAttack()
    {
        canAttack = false;
        
        // Basic attack - override in subclasses for specific behavior
        Debug.Log(gameObject.name + " attacks the player!");
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}