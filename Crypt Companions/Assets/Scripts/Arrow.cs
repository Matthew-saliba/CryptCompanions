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
                // Implement damage logic here
                Debug.Log("Hit Enemy!");
                Destroy(gameObject);
            }
            else if (other.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
            }
        }
        
    }