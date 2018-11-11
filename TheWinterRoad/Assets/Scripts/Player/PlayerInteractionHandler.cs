using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionHandler : PlayerHandler
{
    [SerializeField]
    private Transform playerCenterTransform;

    private Interactable interactable;
    private Transform interactTransform;

    private Vector3 rayCastOrigin;
    public Transform PlayerCenterTransform
    {
        get
        {
            return playerCenterTransform;
        }
    }

    private bool[] interactsAvailable = new bool[3];
    private int currentInteractIndex;
    private bool interactJustOccured; //Check to make sure we still have items to interact

    private bool canInteract = true;

    public Interactable Interactable
    {
        get
        {
            return interactable;
        }
    }

    protected override void Start()
    {
        base.Start();

        m_playerView.PlayerUIHandler.PlayerOpenedMenu += BlockInteract;
        m_playerView.PlayerUIHandler.PlayerClosedMenu += FreeInteract;
    }


    // Update is called once per frame
    void Update ()
    {       
        DetectObject();
	}

    void DetectObject()
    {
        UpdateRaycastOrigin();

        Ray detectionRay = new Ray(rayCastOrigin, transform.forward);
        Debug.DrawRay(detectionRay.origin, detectionRay.direction, Color.blue, 1);
        RaycastHit hit;

        if(Physics.Raycast(detectionRay, out hit, 1))
        {
            if(hit.collider.tag == "Interactable")
            {
                //Check if we've already got Resource info
                if(interactTransform == null || interactTransform != hit.transform || interactJustOccured)
                {
                    FoundInteractable(hit.transform);
                }
            }
            else
            {
                RemoveInteractable();                
            }
        }
        else
        {
            RemoveInteractable();            
        }
    }

    private void FoundInteractable(Transform _interactableTransform)
    {
        interactTransform = _interactableTransform;
        interactable = interactTransform.GetComponent<Interactable>();

        //Get Possible Interactions
        Interact[] interacts = interactable.InteractableItem.interacts;

        //Enable UI
        m_playerView.PlayerUIHandler.InteractActionsHandler.ShowInteractActions(m_playerView,interacts);

        for (int interactIndex = 0; interactIndex < interacts.Length; interactIndex++)
        {
            //Check if we have required items and the correct quantity
            InventoryItemData item = interacts[interactIndex].requiredInventoryItem.requiredInventoryItem;
            int numberRequired = interacts[interactIndex].requiredInventoryItem.quanityOfRequiredInventoryItem;

            if (item.itemName != "Grab")
            {
                if (m_playerView.PlayerInventory.CheckPlayerHasItem(item.itemName, numberRequired))
                {
                    EnableInteractable(interactIndex);
                }
                else
                {
                    DisableInteractableAction(interactIndex);
                }
            }
            else
            {
                EnableInteractable(interactIndex);                
            }
        }

        interactJustOccured = false;
     
    }

    private void EnableInteractable(int interactIndex)
    {
        interactsAvailable[interactIndex] = true;
        m_playerView.PlayerInput.PlayerInteract += InteractWithResource;
    }

    private void DisableInteractableAction(int interactIndex)
    {
        interactsAvailable[interactIndex] = false;
    }

    /// <summary>
    /// Called from Player Input
    /// </summary>
    /// <param name="interactIndex"></param>
    private void InteractWithResource(int interactIndex)
    {
        if (!canInteract)
            return;

        //Check interact is within range
        if (interactsAvailable[interactIndex])
        {
            currentInteractIndex = interactIndex;
            m_playerView.PlayerMovement.InteractedWithResource(currentInteractIndex, interactable.InteractableItem);
        }
    }

    /// <summary>
    /// Triggered from Animation Event
    /// </summary>
    public void Interact()
    {
        interactable.Interact(currentInteractIndex,m_playerView);
        interactJustOccured = true;
    }

    private void RemoveInteractable()
    {
        if(interactTransform != null)
        {
            interactTransform = null;
            m_playerView.PlayerUIHandler.InteractActionsHandler.HideInteractActions();
            m_playerView.PlayerInput.PlayerInteract -= null;
        }
    }

    void UpdateRaycastOrigin()
    {
        rayCastOrigin = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
    }

    private void BlockInteract()
    {
        canInteract = false;
    }

    private void FreeInteract()
    {
        canInteract = true;
    }
}
