using UnityEngine;


    public class Arrow : MonoBehaviour
    {
        [SerializeField] private float speed = 20f;
        [SerializeField] private int damage = 5;

        private void Start()
        {
            
        }

        private void Update()
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Debug.Log("Hit Enemy!");
                
                // Implement damage logic here
                Enemy enemyHealth = other.GetComponent<Enemy>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
                
                Destroy(this.gameObject);
            }
            
            else if (other.CompareTag("Obstacle"))
            {
                Destroy(this.gameObject);
            }
        }
        
    }