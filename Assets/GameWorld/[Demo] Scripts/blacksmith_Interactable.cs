using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class blacksmith_Interactable : MonoBehaviour
{
    public TMP_Text textObject;
    public bool isRange;
    private BlackSmith_UI smith;
    public GameObject BlackSmithUI;
    void Start(){
        smith = BlackSmithUI.GetComponent<BlackSmith_UI>();
    }
    void Update()
    {
        if (isRange){
            if (Input.GetKeyDown(KeyCode.E))
            {
                smith.ToggleInventory();
                //show merchant UI
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        Player player = collision.GetComponent<Player>();
        if (player){
            isRange = true;
            textObject.gameObject.SetActive(true);
            Debug.Log("Player now in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        Player player = collision.GetComponent<Player>();
        if (player){
            isRange = false;
            textObject.gameObject.SetActive(false);
            smith.closeInventory();
            Debug.Log("Player out of range");
        }
    }
}
