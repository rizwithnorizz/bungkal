using UnityEngine;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using System;
using TMPro;
using System.Security.Cryptography.X509Certificates;
using System.Data;


public class BlankPlayer : MonoBehaviour
{
    public Compile compiler = new Compile();
    
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
}
    //Compiler of user properties and its inventory of artifacts
