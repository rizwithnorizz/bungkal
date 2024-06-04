

using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]

public class Artifacts
{
    public Artifacts(int idR, string artName, CollectableType typeR, Sprite iconR, string descripR, int pointR)
    {
        art_id = idR;
        artifact_name = artName;
        type = typeR;
        icon = iconR;
        description = descripR;
        points = pointR;
    }
    
    public int points;
    public string description;
    public Sprite icon;
    public CollectableType type;
    public string artifact_name;
    public int art_id;

}
//These are the object properties for the artifacts that will be given to the players.