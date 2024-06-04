using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Authentication;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngineInternal;

public class Settings_UI : MonoBehaviour
{
    public GameObject settingsUI;
    
    void Start(){
        settingsUI.SetActive(false);
    }
    public void toggleSettings(){
        if (settingsUI.activeSelf){
            settingsUI.SetActive(false);
        } else {
            settingsUI.SetActive(true);
        }
    }

    public void mainMenuButton(){
        signOut();
        SceneManager.LoadScene("Mainscreen");
    }

    public void signOut(){
        try
        {
            AuthenticationService.Instance.SignOut(true);
        }catch (Exception e){
            Debug.Log(e);
        }
    }

    public void exit(){
        Application.Quit();
    }
}
