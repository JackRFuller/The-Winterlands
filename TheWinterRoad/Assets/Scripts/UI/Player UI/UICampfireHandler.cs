using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICampfireHandler : Entity
{
    private PlayerView playerView;
    private InteractableCampFire campfireHandler;

    [SerializeField]
    private GameObject campfireUI;

    [Header("UI Elements")]
    [SerializeField]
    private BurningItemUI[] burningItemsUI = new BurningItemUI[5];
    [SerializeField]
    private TMP_Text burnTimeText;
    [SerializeField]
    private TMP_Text burnIntensityText;

    private void Start()
    {
        campfireHandler = transform.parent.GetComponent<InteractableCampFire>();

        campfireHandler.CampfireActivated += ShowCampfireUI;
        campfireHandler.CampfireInventoryUpdated += UpdateCampfireUI;
        campfireHandler.ItemsBeingBurnt += UpdateItemBurningProgressUI;

        campfireUI.SetActive(false);

        for (int i = 0; i < burningItemsUI.Length; i++)
        {            
            burningItemsUI[i].burningItemProgress.fillAmount = 0;
        }
    }

    public void ShowCampfireUI()
    {
        if (playerView == null)
            playerView = campfireHandler.PlayerView;
                
        playerView.PlayerUIHandler.PlayerOpenedAMenu();
        playerView.PlayerUIHandler.InventoryUIHandler.PrepInventoryForCampfire();

        campfireUI.SetActive(true);        
    }

    public void HideCampfireUI()
    {     
        campfireUI.SetActive(false);
        playerView.PlayerUIHandler.PlayerClosedAMenu();
        playerView.PlayerUIHandler.InventoryUIHandler.HideInventory();
    }

    private void UpdateCampfireUI()
    {
        burnIntensityText.text = campfireHandler.BurnIntensity.ToString();

        for (int inventoryIndex = 0; inventoryIndex < burningItemsUI.Length; inventoryIndex++)
        {
            if(inventoryIndex < campfireHandler.BurningItems.Count)
            {
                burningItemsUI[inventoryIndex].burningItemIcon.sprite = campfireHandler.BurningItems[inventoryIndex].burningItem.itemIcon;
                burningItemsUI[inventoryIndex].burningItemIcon.enabled = true;
            }
            else
            {
                burningItemsUI[inventoryIndex].burningItemIcon.enabled = false;
            }
        }       
    }

    private void UpdateItemBurningProgressUI()
    {
        float burnTimeInHours = campfireHandler.BurnTime / 60f;
        string burnTimeString = "~ " + burnTimeInHours.ToString("F1") + "hrs";
        burnTimeText.text = burnTimeString;

        for (int burnItemIndex = 0; burnItemIndex < campfireHandler.BurningItems.Count; burnItemIndex++)
        {
            float progress = campfireHandler.BurningItems[burnItemIndex].elapsedBurnTime / campfireHandler.BurningItems[burnItemIndex].burningItem.burnTime;
            float fillAmount = 1 - progress;
            burningItemsUI[burnItemIndex].burningItemProgress.fillAmount = fillAmount;
        }
    }
}

[System.Serializable]
public class BurningItemUI
{
    public Image burningItemIcon;
    public Image burningItemProgress;
}
