using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class LeaderboardGet : MonoBehaviour
{
    public TMP_InputField textf;
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
                textf.text = users.downloadHandler.text;
                // Handle the response if needed
            }
        }
   }
}
