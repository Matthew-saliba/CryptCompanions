using UnityEngine;

namespace DefaultNamespace
{
    public class ArrowShop : ShopTile
    {
        protected override void TryPurchase(Player player)
        {
            PlayerRanged playerRanged = player.GetComponent<PlayerRanged>();
            if (player.GetGold() >= itemCost)
            {
                player.AddGold(-itemCost);
                playerRanged.AddArrows(30);
                Debug.Log("Arrows purchased!");
            }
            else
            {
                Debug.Log("Not enough gold to purchase arrows.");
            }
        }
    }
}