using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordField_UI : MonoBehaviour
{
    public TMP_InputField passwordField;
    public string actualPassword;
    public int strPos;
    void Start(){
        passwordField.contentType = TMP_InputField.ContentType.Password;
    }
    // Update is called once per frame
}
