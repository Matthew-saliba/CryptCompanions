using UnityEngine;
using System.Collections;

public class MeleeEnemyAI : EnemyAI
{
    [SerializeField] protected float spawnAnimationLength = 2.3f;
    [SerializeField] private Collider weaponCollider; // Reference to the weapon collider for melee attacks
    
    protected override void Start()
    {
        base.Start();
        
        if (weaponCollider != null)
            weaponCollider.enabled = false;
        
        //Play spawn animation
        if (animator != null)
        {
            StartCoroutine(SpawnAnimation());
        }
        Debug.Log(gameObject.name + " spawns with animation for " + spawnAnimationLength + " seconds.");
    }
    private IEnumerator SpawnAnimation()
    {
        enabled = false; //Disable AI logic during spawn animation
        
        // Play spawn animation
        if (animator != null)
        {
            animator.SetTrigger("Spawn");
        }
        
        
        yield return new WaitForSeconds(spawnAnimationLength);
        
        
        Debug.Log(gameObject.name + " spawn animation complete.");
        
        //Re-enable AI logic after spawn animation
        enabled = true;
    }
    
    protected override IEnumerator PerformAttack()
    {
        canAttack = false;
        
        // Trigger attack animation
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }
        
        // Enable hitbox during attack (you'll fine-tune this timing)
        weaponCollider.enabled = true;
        
        yield return new WaitForSeconds(1f); // Adjust timing
        
        // Disable hitbox after attack window
        weaponCollider.enabled = false;
        
        yield return new WaitForSeconds(attackCooldown - 0.75f);
        canAttack = true;
    }
}