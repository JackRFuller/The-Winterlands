using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionHandler : PlayerHandler
{
    private Interactable interactable;

    private Bounds colliderBounds;

    public RayCastOrigins rayCastOrigins;



    protected override void Start()
    {
        base.Start();
        colliderBounds = m_playerView.PlayerCollider.bounds;
    }


    // Update is called once per frame
    void Update ()
    {
        UpdateRayCastOrigins();
        DetectObject();
	}

    void DetectObject()
    {
        
        Ray ray = new Ray(rayCastOrigins.bottomLeft, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 0.1f);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 1))
        {
            if(hit.collider.tag == "Interactable")
            {
                interactable = hit.collider.GetComponent<Interactable>();
                interactable.PlayerInDistanceToInteract();
            }
            else
            {
                if(interactable != null)
                {
                    interactable.PlayerOutOfDistanceToInteract();
                    interactable = null;
                }
            }
        }
        else
        {
            if (interactable != null)
            {
                interactable.PlayerOutOfDistanceToInteract();
                interactable = null;
            }
        }
        

       
    }

    public void UpdateRayCastOrigins()
    {
        rayCastOrigins.bottomLeft = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        rayCastOrigins.bottomRight = new Vector3(transform.position.x + 0.4f, transform.position.y, transform.position.z);
        rayCastOrigins.bottomMiddle = transform.position;

        rayCastOrigins.rayCastOriginPositions = new Vector3[] { rayCastOrigins.bottomLeft, rayCastOrigins.bottomRight, rayCastOrigins.bottomMiddle };
    }

    public struct RayCastOrigins
    {
        public Vector3 topLeft, topRight, topMiddle;
        public Vector3 middleLeft, middleRight, middleMiddle;
        public Vector3 bottomLeft, bottomRight, bottomMiddle;

        public Vector3[] rayCastOriginPositions;
    }

}
