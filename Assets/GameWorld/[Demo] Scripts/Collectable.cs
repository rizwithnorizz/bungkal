using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Collectable : MonoBehaviour
{        
    private QuestionScript _question;
    public CollectableType type;
    private Player player;

    public int health = 100;
    void Start(){
        _question = FindObjectOfType<QuestionScript>();
        player = FindObjectOfType<Player>();
    }
    public void grabArtifact(){ 
        if (type == CollectableType.QUESTION){
            _question.generateQuestion();
            Debug.Log("Question Type");
        }else if (type == CollectableType.NONE) {
            Debug.Log("No item");
        } else if (type == CollectableType.DUST){
            Player player = FindObjectOfType<Player>();
            player.giveDustCoins(new System.Random().Next(0, 101));
        }
        Destroy(this.gameObject);
    }
    //When a player comes across this object, it will do the action that is specified above
}
public enum CollectableType{
    NONE, QUESTION, DUST
}
