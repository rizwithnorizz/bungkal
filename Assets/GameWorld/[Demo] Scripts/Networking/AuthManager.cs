using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Authentication; //Login Package
using System.Threading.Tasks; //Task functions
using UnityEngine.UI;
using Unity.Services.Core; //
using TMPro;
using System;
using UnityEngine.Networking;
using UnityEngine.SceneManagement; //Text fields
public class AuthManager : MonoBehaviour
{
    public GameObject CloudObject;
    public GameObject passwordObject;
    public TMP_Text status;
    //public GameObject LocalFile;
    public TMP_InputField username;
    public TMP_InputField password;
    private CloudSaveScript cloud;
    bool canLogin = false;

    public async void Start(){
        await UnityServices.InitializeAsync();
        cloud = CloudObject.GetComponent<CloudSaveScript>();
    }

    public IEnumerator GetData_Coroutine(Action callback)
    {
        string name = username.text;
        string pass = password.text;
        WWWForm form = new WWWForm();
        form.AddField("username", name);
        form.AddField("password", pass);
        string URL = "http://localhost/bungkal/userSelect.php";
        using (UnityWebRequest users = UnityWebRequest.Post(URL, form))
        {
            yield return users.SendWebRequest();
            if (users.result == UnityWebRequest.Result.ConnectionError)
            {
                status.text = users.downloadHandler.text;
            }
            else if (users.result == UnityWebRequest.Result.Success)
            {
                status.text = users.downloadHandler.text;
                if (users.downloadHandler.text == "Successfully logged in, wait for a moment"){
                    Debug.Log("Correct Username and Password");
                    canLogin = true;
                    callback();
                } else {
                    Debug.Log("Incorrect username or password");
                }   
            }
            else
            {
                Debug.Log("User is not registered");
            }
        }
    }
    public IEnumerator RegisterData_Coroutine(Action callback)
    {
        confirmPassword Confirm = FindAnyObjectByType<confirmPassword>();
        if (Confirm.canRegister){
            string name = username.text;
            string pass = password.text;
            WWWForm form = new WWWForm();
            form.AddField("username", name);
            form.AddField("password", pass);
            string URL = "http://localhost/bungkal/register.php";
            using (UnityWebRequest users = UnityWebRequest.Post(URL, form))
            {
                yield return users.SendWebRequest();
                if (users.result == UnityWebRequest.Result.ConnectionError)
                {
                    status.text = users.downloadHandler.text;
                }
                else if (users.downloadHandler.text == "Error101")
                {
                    status.text = "Player username already registered";
                }
                else
                {
                    status.text = users.downloadHandler.text;
                    StaticData.SaveID(Int32.Parse(users.downloadHandler.text));
                    StaticData.SaveName(name);
                    callback();
                }
            }
        } else {
            status.text = "Password is invalid (Must have a minimum of 8 characters, atleast 1 Upper case letter, 1 lower case letter, 1 number, and 1 special character)";
        }
        
    }
    public void Register()
    {
        StartCoroutine(RegisterData_Coroutine(GetDataCallbackRegister));
    }

    private void GetDataCallbackRegister()
    {
        RegisterTask();
    }
    public async void RegisterTask(){
        await SignUpWithUsernamePasswordAsync();
    }

    public void Login(){ 
        StartCoroutine(GetData_Coroutine(GetDataCallbackLogin));
    }

    private void GetDataCallbackLogin()
    {
        loginTask(); // Call loginTask after GetData_Coroutine completes
    }

    public async void loginTask(){
        if (canLogin){
            await SignInWithUsernamePasswordAsync();
            SceneManager.LoadScene("GameWorld");
            StaticData.Logged();
        } else {
            status.text = "Try logging in again";
        }
    }
    async Task SignUpWithUsernamePasswordAsync()
        {
        try
        {
            await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(username.text, password.text);
            await cloud.exportBlank();
            SceneManager.LoadScene("GameWorld");
            Debug.Log("Successfully signed up! Username: "+username.text);
        }
        catch (AuthenticationException ex)
        {
            Debug.LogException(ex);
        }
    }
    async Task SignInWithUsernamePasswordAsync()
    {
        try
        {
            await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(username.text, password.text);
            Debug.Log("SignIn is successful! Username: "+username.text);
            Debug.Log("Login Successful: Cloud Database");
            cloud.import();
            //LocalFileSave Local = LocalFile.GetComponent<LocalFileSave>();
            //Local.OutputJSON(); FILE SAVE TO LOCAL //Changed to On-Login action
        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
    }
}



/*
 async Task SignInAnonymous(){
        try{
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            print("Signed in");
            Debug.Log(AuthenticationService.Instance.PlayerId);
        }catch(AuthenticationException ex){
            print("Error");
            Debug.Log(ex);
        }
    }*/
    //ONLY USE WHEN DOING A DEMO



//This is where the user authenticates themselves. Though, this will be modified on the final version of the app. Still a work in progress but it works