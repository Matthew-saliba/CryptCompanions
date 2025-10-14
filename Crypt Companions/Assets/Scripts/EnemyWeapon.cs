using UnityEngine;

    public class EnemyWeapon : MonoBehaviour
    {
        [SerializeField] private int damage = 15;
    
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter called with: " + other.name);
    
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player detected - dealing damage!");
                other.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
            else
            {
                Debug.Log("Hit something that's not the player");
            }
        }
    }
