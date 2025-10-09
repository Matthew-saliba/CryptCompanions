using UnityEngine;

namespace DefaultNamespace
{
    public class FlaskShop : ShopTile
    {
        protected override void TryPurchase(Player player)
        {
            if (player.GetGold() >= itemCost)
            {
                player.AddGold(-itemCost);
                player.AddFlask(1);
                Debug.Log("Flask purchased!");
            }
            else
            {
                Debug.Log("Not enough gold to purchase flask.");
            }
        }
    }
}