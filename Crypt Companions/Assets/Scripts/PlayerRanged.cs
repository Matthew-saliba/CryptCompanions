using UnityEngine;
using System.Collections;

public class PlayerRanged : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    private bool isShooting = false;
    private Animator animator;
    private int arrows;

    void Awake()
    {
        animator = GetComponent<Animator>();
        arrows = PlayerData.Arrows;
    }
    private void Update()
    {
        
    }

    void OnSecondaryAttack()
    {
        if (!isShooting) 
        {
            //Implement shooting animation here 
            if (animator != null)
            {
                animator.SetTrigger("Shoot" ); 
            }

            Shoot();

        }  
    }
    
    private void Shoot()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            StartCoroutine(ShootMultipleProjectiles());
        }
        else
        {
            Debug.LogWarning("Arrow prefab or fire point is not set");
        }
    }
    
    IEnumerator ShootMultipleProjectiles()
    {
        isShooting = true;
        
        for (int i = 0; i < 3; i++)
        {
            // Spawn one arrow
            if (projectilePrefab != null && firePoint != null && arrows > 0)
            {
                GameObject arrow = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation * projectilePrefab.transform.rotation);
                arrows--;
            }
            // Wait before next shot
            yield return new WaitForSeconds(0.2f); // Adjust timing as needed
        }
        
        yield return new WaitForSeconds(0.25f);
        isShooting = false;
    }
    
    public void AddArrows(int count)
    {
        arrows += count;
    }
    
    public int GetArrows()
    {
        return arrows;
    }
}
