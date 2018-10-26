using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionHandler : PlayerHandler
{
    private Interactable interactable;
    private Transform interactTransform;

    private Vector3 rayCastOrigin;

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
                    Debug.Log("Found");
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

        //Check if we've got associated tool
        InventoryItem requiredItem = interactable.InteractableItem.requiredItem;

        if(requiredItem.itemName != "Grab")
        {
            if(m_playerView.PlayerInventory.CheckPlayerHasItem(requiredItem.itemName,interactable.InteractableItem.quantityOfRequiredItem))
            {
                EnableInteractable();
            }
            else
            {
                DisableInteractable();
            }
        }
        else
        {
            EnableInteractable();
        }
    }

    private void EnableInteractable()
    {
        m_playerView.PlayerInput.PlayerInteracted.AddListener(InteractWithResource);
        interactable.PlayerWithinDistanceToInteract(true);
    }

    private void DisableInteractable()
    {
        interactable.PlayerWithinDistanceToInteract(false);
    }

    private void InteractWithResource()
    {
        m_playerView.PlayerMovement.InteractedWithResource(interactable.InteractableItem);
    }

    /// <summary>
    /// Triggered from Animation Event
    /// </summary>
    public void Interact()
    {
        interactable.Interact(m_playerView);
    }

    private void RemoveInteractable()
    {
        if(interactTransform != null)
        {
            interactable.PlayerOutOfDistanceToInteract();

            interactTransform = null;
            m_playerView.PlayerInput.PlayerInteracted.RemoveListener(InteractWithResource);
        }
    }

    void UpdateRaycastOrigin()
    {
        rayCastOrigin = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
    }
}
