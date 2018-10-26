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

    public void SetupInteractUI(Interactable _interactable, Sprite _interactIcon, bool _hasProgressBar)
    {
        interactable = _interactable;
        interactIconImage.sprite = _interactIcon;

        if(!_hasProgressBar)
        {
            DisableProgressBar();
        }      

        interactable.PlayerWithinDistance += ShowInteractUI;
        interactable.PlayerOutOfDistance += HideInteractUI;

        HideInteractUI();
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
