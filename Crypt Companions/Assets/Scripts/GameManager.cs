using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        void Update(){
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length == 0)
            {
                GameObject[] destructables = GameObject.FindGameObjectsWithTag("Destructable");
                foreach (GameObject destructable in destructables)
                {
                    Destroy(destructable);
                }
            }
        }
        
        public void SavePlayerData()
        {
            PlayerData.CurrentHealth = FindObjectOfType<Player>().GetCurrentHealth();
            PlayerData.HealFlasks = FindObjectOfType<Player>().GetFlask();
            PlayerData.CurrentGold = FindObjectOfType<Player>().GetGold();
            PlayerData.Arrows = FindObjectOfType<PlayerRanged>().GetArrows();
        }
    }
