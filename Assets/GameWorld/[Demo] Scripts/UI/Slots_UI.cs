using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Slots_UI : MonoBehaviour
{
    public Action<Slots_UI> OnItemClicked, OnRightMouseBtnClick;
    public Image icon;
    public bool empty = true;
    public Artifacts artNew;
    public int index;
    public void SetItem(Artifacts art, int n){
        index = n;
        artNew = art;
        icon.sprite = art.icon;
        icon.color = new Color(1,1,1,1);  
        empty = false;
        gameObject.SetActive(true);
        
    }

    public void OnPointerClick(BaseEventData data){
        PointerEventData pointerData = (PointerEventData)data;
         if (pointerData.button == PointerEventData.InputButton.Right)
            {
                OnRightMouseBtnClick?.Invoke(this);
            }
            else
            {
                OnItemClicked?.Invoke(this);
            }
    }

    public void Show(){
        gameObject.SetActive(true);
    }
    public void Hide(){
        gameObject.SetActive(false);
    }

    


}
