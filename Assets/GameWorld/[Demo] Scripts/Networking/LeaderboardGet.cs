using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LeaderboardGet : MonoBehaviour
{

    string envPath = Application.dataPath + "/.env";
    public TMP_Text textf;
    string DB_URL;
    void Start()
    {
        EnvLoader.LoadEnv(envPath);
        DB_URL = EnvLoader.GetEnv("DB_URL");
        StartCoroutine(GetData_Coroutine());
    }

    public IEnumerator GetData_Coroutine(){
        string URL = "http://"+DB_URL+"/bungkal/leaderboardAccumulate.php";
    

        using (UnityWebRequest users = UnityWebRequest.Get(URL)){
            yield return users.SendWebRequest();
            if (users.result == UnityWebRequest.Result.ConnectionError || users.result == UnityWebRequest.Result.ProtocolError){
                textf.text = users.error;
            }else{
                string [] result = users.downloadHandler.text.Split("|");
                foreach(string s in result){
                    textf.text += (s + "\n");
                }
                // Handle the response if needed
            }
        }
   }
}
