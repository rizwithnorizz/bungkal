using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tools
{
    public Tools(string _toolname, int _damage, int _dmgMultiply, int _luck, string _desc, Sprite _icon, int _cost){
        toolname = _toolname;
        damage = _damage;
        damageMultiplier = _dmgMultiply;
        luckMultiplier = _luck;
        description = _desc;
        icon = _icon;
        cost = _cost;
    }
        public int cost;
        public Sprite icon;
        public string toolname;
        public int damage;
        public int damageMultiplier;
        public int luckMultiplier;
        public string description;

}