using UnityEngine;
public class EnemyHealth : Health
{
    protected override void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }
}