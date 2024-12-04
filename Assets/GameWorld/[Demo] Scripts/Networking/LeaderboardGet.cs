using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LeaderboardGet : MonoBehaviour
{
    public TMP_Text textf;
    void Start()
    {
        StartCoroutine(GetData_Coroutine());
    }

    public IEnumerator GetData_Coroutine(){
        string URL = "http://localhost/bungkal/leaderboardAccumulate.php";
    

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
