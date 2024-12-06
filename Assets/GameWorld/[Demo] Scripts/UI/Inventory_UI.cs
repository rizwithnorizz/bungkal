using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class Inventory_UI : MonoBehaviour, IPointerClickHandler
{
    public Player player;
    public GameObject inventoryPanel;
    public List<Slots_UI> slots = new List<Slots_UI>();
    void Start(){
        inventoryPanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {   
            resetDescription();
            ToggleInventory();
        }
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
    while (x < player.compiler.artifactNew.Count)
    {
        var artifact = player.compiler.artifactNew[x];
        if (artifact != null)
        {
            slots[x].SetItem(artifact, x);
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
    private void setDescription(Artifacts art){
        title.text = art.artifact_name;
        descriptionText.text = art.description;
        iconUI.sprite = art.icon;
    }
    private void HandleShowItemActions(Slots_UI uI)
    {
        throw new NotImplementedException();
    }

    private void HandleItemSelect(Slots_UI uI)
    {
        if (uI.artNew != null)
        {
            setDescription(uI.artNew);
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
