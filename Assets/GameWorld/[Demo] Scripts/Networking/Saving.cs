using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Unity.Services.CloudSave;
using Unity.Services.Core;
using UnityEngine;

public class Saving : MonoBehaviour
{
    
    public TextAsset jsonText;
    public GameObject PlayerFile;
    private Player player;
    public async void Start(){
        await UnityServices.InitializeAsync();
        player = PlayerFile.GetComponent<Player>();
    }
    
    public async void export()
    {
        Debug.Log("Player saving: " + player.compiler.username);
        string strOutput = JsonUtility.ToJson(player.compiler); //string = isaiah.text
        File.WriteAllText(Application.dataPath + "/PlayerFile.json", strOutput); //file = string
        Debug.Log("Local upload");


        byte[] file = System.IO.File.ReadAllBytes(Application.dataPath + "/PlayerFile.json");
        await CloudSaveService.Instance.Files.Player.SaveAsync("PlayerFile", file);
        Debug.Log("Cloud upload");
    }
    public async void import()
    {
        Debug.Log("Cloud download");
        byte [] file = await CloudSaveService.Instance.Files.Player.LoadBytesAsync("PlayerFile");
        string jsonData = Encoding.UTF8.GetString(file);
        File.WriteAllText(Application.dataPath + "/PlayerFile.json", jsonData);

        Debug.Log("Local download");
        player.compiler = JsonUtility.FromJson<Player.Compile>(jsonData);
        //Debug.Log("File successfully saved locally");
        //THIS SHOULD BE TASK 1
    }

    public async Task exportBlank()
    {
        StaticData.exportInitial(); //adding username and userid to the blank player entity and then exporting it to a text file
        byte[] file = System.IO.File.ReadAllBytes(Application.dataPath + "/BlankPlayer.json");
        await CloudSaveService.Instance.Files.Player.SaveAsync("PlayerFile", file);
        //Debug.Log("File successfully uploaded to player database");
    }

    
    public async void DeletePlayerFile()
    {
        await CloudSaveService.Instance.Data.Player.DeleteAllAsync();
    }
}
