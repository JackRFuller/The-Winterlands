using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInteractHandler : MonoBehaviour
{
    private Interactable interactable;
    
    [Header("UI Components")]
    [SerializeField]
    private Image interactIconImage;
    [SerializeField]
    private Image interactBlockedImage;
    [SerializeField]
    private GameObject interactUIObject;
    [SerializeField]
    private GameObject progressBarObject;

    [Header("Progress Bar Components")]
    [SerializeField]
    private Image progressBarImage;
    private float progressMax;

    public void SetupInteractUI(Interactable _interactable)
    {
        interactable = _interactable;
        interactIconImage.sprite = interactable.InteractableItem.requiredItem.itemIcon;

        if(interactable.InteractableItem.interactType == InteractableItem.InteractableItemType.ItemPickup)
        {
            DisableProgressBar();
        } 
        else
        {
            progressMax = interactable.InteractableItem.numberOfNeededInteracts;
        }

        interactable.PlayerWithinDistance += ShowInteractUI;
        interactable.PlayerOutOfDistance += HideInteractUI;

        HideInteractUI();
    }

    public void SetInteractableProgress(float progress)
    {
        float progressPercent = progress / progressMax;
        progressBarImage.fillAmount = progressPercent;
    }

    private void ShowInteractUI(bool _canInteract)
    {
        if(_canInteract)
        {
            interactBlockedImage.enabled = false;
        }
        else
        {
            interactBlockedImage.enabled = true;
        }

        interactUIObject.SetActive(true);
    }

    private void HideInteractUI()
    {
        interactUIObject.SetActive(false);
    }

    private void SetInteractUIToCamera()
    {

    }

    private void DisableProgressBar()
    {
        progressBarObject.SetActive(false);
    }
}
