using UnityEngine;
using System.Collections;
public class PlayerMelee : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Collider meleeCollider;
    [SerializeField] private float attackDuration = 1f; // How long to keep collider on
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        
        if (meleeCollider != null)
        {
            meleeCollider.enabled = false;
        }
    }
    
    private void Update()
    {
        
    }
    
    void OnPrimaryAttack()
    {
        PerformMeleeAttack();
    }
    
    private void PerformMeleeAttack()
    {
        if (animator != null)
        {
            animator.SetTrigger("Slash");
        }
        
        if (meleeCollider != null)
        {
            meleeCollider.enabled = true;
            StartCoroutine(DisableColliderAfterTime());
        }
    }
    
    IEnumerator DisableColliderAfterTime()
    {
        yield return new WaitForSeconds(attackDuration);
        meleeCollider.enabled = false;
    }
    
}
