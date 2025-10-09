using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        public void SavePlayerData()
        {
            PlayerData.CurrentHealth = FindObjectOfType<Player>().GetCurrentHealth();
            PlayerData.HealFlasks = FindObjectOfType<Player>().GetFlask();
            PlayerData.CurrentGold = FindObjectOfType<Player>().GetGold();
            PlayerData.Arrows = FindObjectOfType<PlayerRanged>().GetArrows();
        }
    }
