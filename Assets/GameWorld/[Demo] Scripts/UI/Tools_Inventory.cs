using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class Tools_Inventory : MonoBehaviour, IPointerClickHandler
{
    public static int currentIndex;
    public TMP_Text damageText; 
    public Player player;
    public GameObject inventoryPanel;
    public List<Tools_UI> slots = new List<Tools_UI>();
    void Start(){
        inventoryPanel.SetActive(false);
    }
    public void ToggleInventory(){
        if (!inventoryPanel.activeSelf){
            inventoryPanel.SetActive(true);
            Setup();
        }else{
            inventoryPanel.SetActive(false);
        }
    }

    public void closeInventory(){
        inventoryPanel.SetActive(false);
    }

    void Setup()
    {
    int x = 0;
    while (x < player.compiler.playerTools.Count)
    {
        var tool = player.compiler.playerTools[x];
        if (tool != null)
        {
            Debug.Log("Loaded tools");
            slots[x].SetItem(tool, x);
            slots[x].OnItemClicked += HandleItemSelect;
            slots[x].OnRightMouseBtnClick += HandleShowItemActions;
            //Debug.Log("Setup: Added artifact: " + artifact.artifact_name);
        }
        else
        {
            Debug.LogWarning("Setup: Found null or NONE type artifact at index " + x);
        }
        x++;
    }
    for (int i = x; i < slots.Count; i++)
    {
        if (slots[i].empty == true)
        {
            slots[i].Hide();
        }
    }
}

    public TMP_Text title;
    public TMP_Text descriptionText;
    public Image iconUI;
    private void resetDescription(){
        title.text = "";
        descriptionText.text = "";
        iconUI.sprite = null;
    }
    private void setDescription(Tools tools){
        title.text = tools.toolname;
        descriptionText.text = tools.description;
        iconUI.sprite = tools.icon;
        damageText.text = tools.damage.ToString();
    }
    private void HandleShowItemActions(Tools_UI uI)
    {
        throw new NotImplementedException();
    }

    private void HandleItemSelect(Tools_UI uI)
    {
        if (uI.toolsSale != null)
        {
            Debug.Log("Item selected");
            setDescription(uI.toolsSale);
            currentIndex = uI.index;
        }
        else
        {
            Debug.LogError("Selected item is null.");
        }

    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}