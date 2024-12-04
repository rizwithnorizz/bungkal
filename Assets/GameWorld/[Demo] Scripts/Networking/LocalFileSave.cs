using UnityEngine;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using System;
using Unity.VisualScripting;

public class LocalFileSave : MonoBehaviour
{
    public TextAsset jsonText;
    public GameObject PlayerFile;
    private Player player;
    void Start()
    {
        player = PlayerFile.GetComponent<Player>();
    }
    public void export()
    {
        //GAME DATA INTO JSON FILE
        Debug.Log("Player saving: " + player.compiler.username);
        string strOutput = JsonUtility.ToJson(player.compiler); //string = isaiah.text
        File.WriteAllText(Application.dataPath + "/PlayerFile.json", strOutput); //file = string
        Debug.Log("Local Player File successfully imported to Unity Player Attributes");
    }

    public void import()
    {
        //JSON FILE TO GAME DATA
        Debug.Log("Local");
        player.compiler = JsonUtility.FromJson<Player.Compile>(jsonText.text);
        //Debug.Log("Unity Player Attributes successfully imported to Local Player File");
        //THIS SHOULD BE TASK 2
    }
}

//This reads and writes the player's data into and from the PlayerFile.JSON file