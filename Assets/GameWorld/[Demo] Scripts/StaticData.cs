using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Unity.Services.CloudSave;
using UnityEngine;

public class StaticData : MonoBehaviour
{
    private static string user;
    private static int ID;
    private static bool logged = false;

    public static int GetID()
    {
        Debug.Log("Player ID: "+ID);
        return ID;
    }
    public static void SaveID(int receive)
    {
        ID = receive;
    }
    public static string GetUsername(){
        Debug.Log("Player Username: "+user);
        return user;
    }
    public static void SaveName(string username)
    {
        user = username;
    }
    
    public static void exportInitial()
    {
        BlankPlayer player = FindObjectOfType<BlankPlayer>();
        player.compiler.username = user;
        player.compiler.userID = ID;
        player.compiler.heatlhPoints = 10;
        Debug.Log("Player saving: " + player.compiler.username);
        string strOutput = JsonUtility.ToJson(player.compiler); //string = isaiah.text
        File.WriteAllText(Application.dataPath + "/BlankPlayer.json", strOutput); //file = string
        Destroy(player);
        //When registering the player, RUN THIS AS FIRST
    }

    public static void Logged()
    {
        if (logged == true) {
            logged = false;
        } else {
            logged = true;
        }
    }   

    public static bool getLogged(){
        return logged;
    }





}
