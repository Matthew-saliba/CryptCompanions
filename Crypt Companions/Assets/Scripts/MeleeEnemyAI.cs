using UnityEngine;
using System.Collections;
public class MeleeEnemyAI : EnemyAI
{
    protected override IEnumerator PerformAttack()
    {
        canAttack = false;
        
        // Trigger attack animation
        Debug.Log(gameObject.name + " performs melee attack!");
        // Animation system and weapon collider handle timing and damage
        
        // Wait for attack cooldown before allowing next attack
        yield return new WaitForSeconds(attackCooldown);
        
        canAttack = true;
    }
}