using System;
using UnityEngine;

public class LevelCircle : MonoBehaviour, IInteractable
{
    [SerializeField] private string nextLevelName;
    private bool playerInRange;

    private void Start()
    {
        Debug.Log(nextLevelName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered");
            playerInRange = true;
            other.GetComponent<Player>().SetCurrentInteractable(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited LevelCircle range");
            playerInRange = false;
            other.GetComponent<Player>().ClearCurrentInteractable(this);
        }
    }

    public void Interact(Player player)
    {
        Debug.Log("Interaction with LevelCircle");
        if (playerInRange)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                Debug.Log("GameManager found");
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