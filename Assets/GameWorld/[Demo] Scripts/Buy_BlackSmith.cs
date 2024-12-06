using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy_BlackSmith : MonoBehaviour
{
    
    public Blacksmith blackSmith;
    public Player player;
    public void callBuy()
    {
        int index = BlackSmith_UI.currentIndex;
        if (player.compiler.dustCoins >= blackSmith.compiler.toolsSale[index].cost){
            player.AddTools(blackSmith.compiler.toolsSale[index]);
            player.decreaseDustCoins(blackSmith.compiler.toolsSale[index].cost);
            Debug.Log("Purchase successful");
        }
    }
}
