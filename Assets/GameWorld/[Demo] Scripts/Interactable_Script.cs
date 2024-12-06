using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public Collectable collect;
    public bool isRange;
    PressIcon rangeKey;
    public int health = 100;
    private Player player;
    public TMP_Text healthText;
    void Start(){
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        if (isRange){
            if (Input.GetKeyDown(KeyCode.E))
            {
                updateHealth();
                if (health < 0)
                    collect.grabArtifact();
            }
        }
    }

    void updateHealth(){
        health -= player.compiler.equippedTool.damage + (player.compiler.equippedTool.damage * player.compiler.equippedTool.damageMultiplier);
        healthText.text = health.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision){
        Player player = collision.GetComponent<Player>();
        rangeKey = FindObjectOfType<PressIcon>();
        if (player){
            rangeKey.Show();
            isRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        Player player = collision.GetComponent<Player>();
        if (player){
            isRange = false;
            rangeKey.Hide();
        }
    }
}
