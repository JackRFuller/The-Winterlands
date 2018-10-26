using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventoryButtonHandler : Entity
{
    [SerializeField]
    private GameObject labelObject;
    [SerializeField]
    private TMP_Text labelText;
    private int labelIndex;

    private void Start()
    {
        labelObject.SetActive(false);
    }

    public void AssignItemIndex(int itemIndex)
    {
        labelIndex = itemIndex;
    }

    public void OnHoverOver()
    {
        if(GameManager.Instance.PlayerView.PlayerInventory.Inventory.Count > labelIndex)
        {
            labelText.text = GameManager.Instance.PlayerView.PlayerInventory.Inventory[labelIndex].itemName;
            labelObject.SetActive(true);
        }
    }

    public void OnHoverExit()
    {
        labelObject.SetActive(false);       
    }
}
