using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void SwitchLogin(){
        if (StaticData.getLogged()){
            SceneManager.LoadScene("GameWorld");
        }else{
            SceneManager.LoadScene("Login");
        }
    }
    public void SwitchRegister(){
        SceneManager.LoadScene("Register");
    }

    public void SwitchLeaderboard(){
        SceneManager.LoadScene("Leaderboards");
    }
    public void SwitchMain(){
        SceneManager.LoadScene("Mainscreen");
    }

    public void exit(){
        Application.Quit();
    }
}
