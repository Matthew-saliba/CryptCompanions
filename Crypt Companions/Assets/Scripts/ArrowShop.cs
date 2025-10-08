using UnityEngine;
    public class ArrowShop : ShopTile
    {
        protected override void TryPurchase()
        {
            GameObject player = GameObject.FindWithTag("Player");
            Player playerScript = player.GetComponent<Player>();
            PlayerRanged playerRanged = player.GetComponent<PlayerRanged>();
            if (playerScript.GetGold() >= itemCost)
            {
                playerScript.AddGold(-itemCost);
                playerRanged.AddArrows(30);
                Debug.Log("Arrows purchased!");
            }
            else
            {
                Debug.Log("Not enough gold to purchase arrows.");
            }
        }
    }
