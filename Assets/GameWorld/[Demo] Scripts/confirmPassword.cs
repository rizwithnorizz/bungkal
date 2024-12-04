using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class confirmPassword : MonoBehaviour
{  
    public TMP_Text status;
    public TMP_InputField password;
    bool pValid;
    public TMP_InputField confirmPasswordField;

    void Start(){
        pValid = false;
    }
    public bool canRegister = false;
    void Update(){
        if (status.text != null){
            string pass = password.text;
            if (IsPasswordValid(pass)) {
                confirmPasswordField.interactable = true;
                pValid = true;
            } else {
                status.text = "Password must have a minimum of 8 characters, atleast 1 Upper case letter, 1 lower case letter, 1 number, and 1 special character";
                confirmPasswordField.interactable = false;
            }
        }
        if (confirmPasswordField.text != ""){
            if (confirmPasswordField.text == password.text && pValid == true)
                canRegister = true;
            else 
                status.text = "Passwords do not match";
        } 

        
    }   
    private bool IsPasswordValid(string pass) {
        if (pass.Length < 8)
            return false;

        bool hasUpperCase = false, hasLowerCase = false, hasDigit = false, hasSpecialChar = false;

        foreach (char c in pass) {
            if (char.IsUpper(c))
                hasUpperCase = true;
            else if (char.IsLower(c))
                hasLowerCase = true;
            else if (char.IsDigit(c))
                hasDigit = true;
            else if (!char.IsLetterOrDigit(c))
                hasSpecialChar = true;
        }
        return hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar;
    }
}
