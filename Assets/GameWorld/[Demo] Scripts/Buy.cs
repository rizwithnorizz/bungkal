using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    
    public Trader trader;
    public Player player;
    public void callBuy()
    {
        int index = Merchant_UI.currentIndex;
        if (player.compiler.dustCoins >= trader.compiler.artifactNew[index].cost){
            player.AddArtifact(trader.compiler.artifactNew[index]);
            Debug.Log("Purchase successful");
        }
    }
}
