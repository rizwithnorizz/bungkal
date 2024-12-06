using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Leaderboards : MonoBehaviour
{
    string envPath = Application.dataPath + "/.env";
    string DB_URL;
    void Start(){
         EnvLoader.LoadEnv(envPath);
         DB_URL = EnvLoader.GetEnv("DB_URL");
    }
    public void PostScore(int playerID, string username, Artifacts art){
        StartCoroutine(PostData_Coroutine(playerID, username, art));
    }
   public IEnumerator PostData_Coroutine(int playerID, string userR, Artifacts art){
        string URL = "http://"+DB_URL+"/bungkal/leaderboardsSelect.php";

        int userID = playerID;
        string username = userR;
        int art_ID = art.art_id;
        string ArtifactName = art.artifact_name;
        int point = art.points;

        WWWForm form = new WWWForm();
        form.AddField("userID", userID);
        form.AddField("username", username);
        form.AddField("art_ID", art_ID);
        form.AddField("art_Name", ArtifactName);
        form.AddField("points", point);

        using (UnityWebRequest users = UnityWebRequest.Post(URL, form)){
            yield return users.SendWebRequest();
            if (users.result == UnityWebRequest.Result.ConnectionError || users.result == UnityWebRequest.Result.ProtocolError){
                //outputArea.text = users.error;
            }else{
                Debug.Log(users.downloadHandler.text);
                // Handle the response if needed
            }
        }
   }
}
