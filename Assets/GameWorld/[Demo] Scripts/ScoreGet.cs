using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ScoreGet : MonoBehaviour
{

    public TMP_Text textf;
    public Player player;
    public string username;
    private int totalPoints;
    public static bool newArt;
    void Start()
    {
        newArt = true;
        totalPoints = 0;
        username = player.compiler.username;
    }
    void Update(){
        if (newArt && player.compiler.artifactNew.Count > 0){ 
            totalPoints = 0;
            for(int x = 0; x<player.compiler.artifactNew.Count; x++){
                totalPoints += player.compiler.artifactNew[x].points;
            }
            textf.text = totalPoints.ToString();
            newArt = false;
        }
    }

}
