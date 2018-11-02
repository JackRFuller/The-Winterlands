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

    private int maxInteractsAvailable;
    private int currentInteractIndex;

    protected override void Start()
    {
        base.Start();
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
                if(interactTransform == null || interactTransform != hit.transform)
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
            }
            else
            {
                EnableInteractable(interactIndex);                
            }
        }
     
    }

    private void EnableInteractable(int interactIndex)
    {
        maxInteractsAvailable++;
         m_playerView.PlayerInput.PlayerInteract += InteractWithResource;
    }

    /// <summary>
    /// Called from Player Input
    /// </summary>
    /// <param name="interactIndex"></param>
    private void InteractWithResource(int interactIndex)
    {
        //Check interact is within range
        if(interactIndex <= maxInteractsAvailable)
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
    }

    private void RemoveInteractable()
    {
        if(interactTransform != null)
        {
            interactTransform = null;
            maxInteractsAvailable = 0;
            m_playerView.PlayerInput.PlayerInteract -= InteractWithResource;
            m_playerView.PlayerUIHandler.InteractActionsHandler.HideInteractActions();
        }
    }

    void UpdateRaycastOrigin()
    {
        rayCastOrigin = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
    }
}
