using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public Player player;
    public TMP_Text coinText;
    void Update()
    {
        coinText.text = player.compiler.dustCoins.ToString();
    }
}
