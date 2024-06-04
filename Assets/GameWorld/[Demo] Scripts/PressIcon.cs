using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressIcon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pressIcon;
    void Start()
    {
        pressIcon.SetActive(false);
    }

    public void Hide()
    {
        pressIcon.SetActive(false);
    }

    public void Show()
    {
        pressIcon.SetActive(true);
    }
}
