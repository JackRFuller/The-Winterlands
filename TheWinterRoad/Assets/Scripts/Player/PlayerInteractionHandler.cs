using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionHandler : PlayerHandler
{
    private ResourceHandler resourceHandler;
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
            if(hit.collider.tag == "Resource")
            {
                //Check if we've already got Resource info
                if(interactTransform == null || interactTransform != hit.transform)
                {
                    interactTransform = hit.transform;
                    resourceHandler = hit.collider.GetComponent<ResourceHandler>();

                    //Check if we've got associated tool
                    if (m_playerView.PlayerInventory.CheckPlayerHasTool(resourceHandler.Resource.associatedTool.ToString()))
                    {                        
                        m_playerView.PlayerInput.PlayerInteracted.AddListener(InteractWithResource);
                        resourceHandler.PlayerWithinDistanceToInteract();
                    }
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

    private void InteractWithResource()
    {
        m_playerView.PlayerMovement.InteractedWithResource(resourceHandler.Resource);
        Debug.Log("Interacted");
    }

    private void RemoveInteractable()
    {
        if(interactTransform != null)
        {
            resourceHandler.PlayerOutOfDistanceToInteract();

            interactTransform = null;
            resourceHandler = null;
            m_playerView.PlayerInput.PlayerInteracted.RemoveListener(InteractWithResource);
        }
    }

    void UpdateRaycastOrigin()
    {
        rayCastOrigin = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
    }
}
