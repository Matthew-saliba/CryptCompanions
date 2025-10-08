using UnityEngine;
    public class FlaskShop : ShopTile
    {
        protected override void TryPurchase()
        {
            GameObject player = GameObject.FindWithTag("Player");
            Player playerScript = player.GetComponent<Player>();
            if (playerScript.GetGold() >= itemCost)
            {
                playerScript.AddGold(-itemCost);
                playerScript.AddFlask(1);
                Debug.Log("Flask purchased!");
            }
            else
            {
                Debug.Log("Not enough gold to purchase flask.");
            }
        }
    }
