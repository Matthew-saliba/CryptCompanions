using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Chasing,
        Attacking
    }
    
    [Header("AI State")]
    [SerializeField] protected EnemyState currentState = EnemyState.Idle;
    
    [Header("Detection")]
    [SerializeField] protected float detectionRange = 10f;
    [SerializeField] protected float attackRange = 1f;
    
    [Header("Movement")]
    [SerializeField] protected float moveSpeed = 3f;
    
    [Header("Combat")]
    [SerializeField] protected float attackCooldown = 1.5f;
    [SerializeField] protected int attackDamage = 10;
    
    protected Transform player;
    protected float distanceToPlayer;
    protected bool canAttack = true;
    protected Animator animator;
    
    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        
        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the player has the 'Player' tag.");
        }
        if (animator == null)
        {
            Debug.LogWarning("Animator not found on " + gameObject.name + ". AI will function without animations.");
        }
    }
    
    protected virtual void Update()
    {
        if (player == null) return;
        
        distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        switch (currentState)
        {
            case EnemyState.Idle:
                HandleIdleState();
                break;
            case EnemyState.Chasing:
                HandleChasingState();
                break;
            case EnemyState.Attacking:
                HandleAttackingState();
                break;
        }
    }
    
    protected virtual void HandleIdleState()
    {
        // Check if player is within detection range
        if (distanceToPlayer <= detectionRange)
        {
            currentState = EnemyState.Chasing;
            Debug.Log(gameObject.name + " detected player - switching to Chase state");
        }
        // Stop walking animation when idle
        if (animator != null)
        {
            animator.SetBool("IsWalking", false);
        }
    }
    
    protected virtual void HandleChasingState()
    {
        // Player moved out of detection range
        if (distanceToPlayer > detectionRange)
        {
            currentState = EnemyState.Idle;
            Debug.Log(gameObject.name + " lost player - switching to Idle state");
        }
        // Player is in attack range and we can attack
        else if (distanceToPlayer <= attackRange && canAttack)
        {
            currentState = EnemyState.Attacking;
            StartCoroutine(PerformAttack());
        }
        // Continue chasing
        else
        {
            MoveTowardsPlayer();
        }
    }
    
    protected virtual void HandleAttackingState()
    {
        // Attack finished, decide next state
        if (canAttack)
        {
            if (distanceToPlayer <= attackRange)
            {
                // Player still in range, attack again
                StartCoroutine(PerformAttack());
            }
            else if (distanceToPlayer <= detectionRange)
            {
                // Player moved away but still detected, chase
                currentState = EnemyState.Chasing;
            }
            else
            {
                // Player escaped, go idle
                currentState = EnemyState.Idle;
            }
        }
        // Still attacking, do nothing (wait for attack to finish)
    }
    
    protected virtual void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        
        // Set walking animation
        if (animator != null)
        {
            animator.SetBool("IsWalking", true);
        }

        
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