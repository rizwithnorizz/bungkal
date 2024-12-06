using System.Collections.Generic;
using UnityEngine;

public class Blacksmith : MonoBehaviour 
{
    public Compile compiler = new Compile();
    [System.Serializable]
    public class Compile
    {
        public List<Tools> toolsSale = new List<Tools>();
    }
}