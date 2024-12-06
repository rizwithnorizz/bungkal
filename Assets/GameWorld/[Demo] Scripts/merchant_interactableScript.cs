using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class merchant_interactableScript : MonoBehaviour
{
    public TMP_Text textObject;
    public bool isRange;
    private Merchant_UI traderUI;
    public GameObject UITrading;
    void Start(){
        traderUI = UITrading.GetComponent<Merchant_UI>();
    }
    void Update()
    {
        if (isRange){
            if (Input.GetKeyDown(KeyCode.E))
            {
                traderUI.ToggleInventory();
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
            traderUI.closeInventory();
            Debug.Log("Player out of range");
        }
    }
}
