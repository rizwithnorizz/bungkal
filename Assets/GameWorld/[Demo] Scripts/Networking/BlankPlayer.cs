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
        public List<Artifacts> artifactNew = new List<Artifacts>();
    }
}
    //Compiler of user properties and its inventory of artifacts
