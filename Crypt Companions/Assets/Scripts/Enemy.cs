using UnityEngine;
public class Enemy : Health
{
    [SerializeField] private int gold;
    protected override void Die()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<Player>().AddGold(gold);
        Debug.Log("Enemy died!");
        Destroy(gameObject);
        
    }
}