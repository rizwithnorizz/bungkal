using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public Collectable collect;
    public bool isRange;
    PressIcon rangeKey;
    void Update()
    {
        if (isRange){
            if (Input.GetKeyDown(KeyCode.E))
            {
                collect.grabArtifact();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        Player player = collision.GetComponent<Player>();
        rangeKey = FindObjectOfType<PressIcon>();
        if (player){
            rangeKey.Show();
            isRange = true;
            //Debug.Log("Player now in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        Player player = collision.GetComponent<Player>();
        if (player){
            isRange = false;
            rangeKey.Hide();
            //Debug.Log("Player out of range");
        }
    }
}
