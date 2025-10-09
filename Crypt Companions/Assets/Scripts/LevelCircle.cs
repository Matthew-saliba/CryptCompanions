using UnityEngine;

public class LevelCircle : MonoBehaviour, IInteractable
{
    [SerializeField] private string nextLevelName;
    private bool playerInRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            other.GetComponent<Player>().SetCurrentInteractable(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            other.GetComponent<Player>()?.ClearCurrentInteractable(this);
        }
    }

    public void Interact(Player player)
    {
        if (playerInRange)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.SavePlayerData();
                UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevelName);
            }
            else
            {
                Debug.LogWarning("GameManager not found!");
            }
        }
    }
}