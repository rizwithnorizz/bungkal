using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void SwitchLogin(){
        SceneManager.LoadScene("Login");
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
