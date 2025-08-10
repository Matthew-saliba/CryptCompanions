using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform firePoint;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Needs to be changed to R2/right-click
        {
            Shoot();
        }
    }
    
    private void Shoot()
    {
        if (arrowPrefab != null && firePoint != null)
        {
            GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation * arrowPrefab.transform.rotation);
        }
        else
        {
            Debug.LogWarning("Arrow prefab or fire point is not set.");
        }
    }
}
