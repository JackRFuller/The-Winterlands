using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICampfireHandler : Entity
{
    private PlayerView playerView;
    private InteractableCampFire campfireHandler;

    [SerializeField]
    private GameObject campfireUI;

    [Header("UI Elements")]
    [SerializeField]
    private BurningItemUI[] burningItemsUI = new BurningItemUI[5];

    private void Start()
    {
        campfireHandler = transform.parent.GetComponent<InteractableCampFire>();
        campfireHandler.CampfireActivated += ShowCampfireUI;

        campfireUI.SetActive(false);

        for (int i = 0; i < burningItemsUI.Length; i++)
        {
            burningItemsUI[i].burningItemIcon.sprite = null;
            burningItemsUI[i].burningItemProgress.fillAmount = 0;
        }
    }

    public void ShowCampfireUI()
    {
        if (playerView == null)
            playerView = campfireHandler.PlayerView;
                
        playerView.PlayerUIHandler.PlayerOpenedAMenu();

        campfireUI.SetActive(true);        
    }

    public void HideCampfireUI()
    {     
        campfireUI.SetActive(false);
        playerView.PlayerUIHandler.PlayerClosedAMenu();
    }
}

[System.Serializable]
public class BurningItemUI
{
    public Image burningItemIcon;
    public Image burningItemProgress;
}
