using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLogin : MonoBehaviour
{
    public GameObject _saving;

    void Start()
    {
        Saving save = _saving.GetComponent<Saving>();
        save.import();
    }
}
