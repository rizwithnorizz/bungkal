using UnityEngine;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using System;
using TMPro;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public Slider healthBar;
    public Image equippedIcon;
    public Compile compiler = new Compile();
    public GameObject _save;
    public GameObject _leaderboards;
    private Saving save;
    private Leaderboards lead;
    void Start(){
        save = _save.GetComponent<Saving>();
        lead = _leaderboards.GetComponent<Leaderboards>();
    }

    [System.Serializable]
    public class Compile
    {
        public String username;
        public int userID;
        public int heatlhPoints;
        public int dustCoins;
        public List<Artifacts> artifactNew = new List<Artifacts>();
        public List<Tools> playerTools = new List<Tools>();
        public Tools equippedTool;
    }
    
    public void AddArtifact(Artifacts newArtifact)
    {
        compiler.artifactNew.Add(newArtifact); 
        Debug.Log("Added artifact: "+newArtifact.artifact_name);
        save.export();
        lead.PostScore(compiler.userID, compiler.username, newArtifact);
        ScoreGet.newArt = true;
    }
    public void AddTools(Tools tool)
    {
        compiler.playerTools.Add(tool);
        Debug.Log("Added tool: "+tool.toolname);
        save.export();
    }
    public void decreaseHealth(){
        compiler.heatlhPoints -= 1;
        healthBar.value = compiler.heatlhPoints;
    }
    public void giveDustCoins(int amount){
        compiler.dustCoins += amount;
    }

    public void decreaseDustCoins(int amount){
        compiler.dustCoins -= amount;
    }

    public void equipTool(){
        compiler.equippedTool = compiler.playerTools[Tools_Inventory.currentIndex];
        equippedIcon.sprite = compiler.playerTools[Tools_Inventory.currentIndex].icon;
    }

    public int getToolDamage(){
        return compiler.equippedTool.damage + (compiler.equippedTool.damageMultiplier * compiler.equippedTool.damage);
    }
}
    //Compiler of user properties and its inventory of artifacts
