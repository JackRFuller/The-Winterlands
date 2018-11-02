using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInteractActionsHandler : MonoBehaviour
{
    private PlayerView playerView;

    [Header("Control Icons")]
    [SerializeField]
    private Color enabledColor;
    [SerializeField]
    private Color disabledColor;
    [SerializeField]
    private Image controlIcons;

    public UIInteractAction[] uIInteractActions;    

    public void ShowInteractActions(PlayerView _playerView, Interact[] interacts)
    {
        if (playerView == null)
            playerView = _playerView;

        for (int interactIndex = interacts.Length - 1; interactIndex >= 0; interactIndex--)
        {
            InventoryItemData item = interacts[interactIndex].requiredInventoryItem.requiredInventoryItem;

            //Assign Images to Interact Labels
            uIInteractActions[interactIndex].interactActionIcon.sprite = item.itemIcon;

            if(item.itemName != "Grab")
            {
                //Check if we have the item
                if (!playerView.PlayerInventory.CheckPlayerHasItem(item.itemName, interacts[interactIndex].requiredInventoryItem.quanityOfRequiredInventoryItem))
                {
                    uIInteractActions[interactIndex].interactActionIcon.color = disabledColor;
                }
                else
                {
                    uIInteractActions[interactIndex].interactActionIcon.color = enabledColor;
                }
            }
            else
            {
                uIInteractActions[interactIndex].interactActionIcon.color = enabledColor;
            }

            uIInteractActions[interactIndex].interactActionAnimController.SetBool("isShowing",true);
        }
    }

    public void HideInteractActions()
    {
        for (int interactLabels = 0; interactLabels < uIInteractActions.Length; interactLabels++)
        {
            if(uIInteractActions[interactLabels].interactActionAnimController.GetBool("isShowing"))
                uIInteractActions[interactLabels].interactActionAnimController.SetBool("isShowing", false);
        }
    }

}

[System.Serializable]
public class UIInteractAction
{
    public Animator interactActionAnimController;
    public Image interactControlIcon;
    public Image interactActionIcon;
}

public class InteractActionUI
{
    
}

public class InteractAction
{
    
}
