using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class BlackSmith_UI : MonoBehaviour, IPointerClickHandler
{
    public static int currentIndex;
    public TMP_Text damageText, costText;
    public Blacksmith blackSmith;
    public GameObject inventoryPanel;
    public List<Slots_UI_BlackSmith> slots = new List<Slots_UI_BlackSmith>();
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
    while (x < blackSmith.compiler.toolsSale.Count)
    {
        var tool = blackSmith.compiler.toolsSale[x];
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
        costText.text = tools.cost.ToString();
    }
    private void HandleShowItemActions(Slots_UI_BlackSmith uI)
    {
        throw new NotImplementedException();
    }

    private void HandleItemSelect(Slots_UI_BlackSmith uI)
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
