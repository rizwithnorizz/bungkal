using System.Collections.Generic;
using UnityEngine;

public class Trader : MonoBehaviour 
{
    public Compile compiler = new Compile();
    [System.Serializable]
    public class Compile
    {
        public List<Artifacts> artifactNew = new List<Artifacts>();
    }
}