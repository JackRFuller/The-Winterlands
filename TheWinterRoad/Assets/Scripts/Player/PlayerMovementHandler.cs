using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHandler : PlayerHandler
{
    private const float playerSneakSpeed = 0.5f;
    private const float playerWalkSpeed = 1.0f;
    private const float playerSprintSpeed = 2.0f;

    private Vector3 lastRotation;

    private MovementState movementState = MovementState.Free;
    private enum MovementState
    {
        Frozen,
        Free,
    }

    protected override void Start()
    {
        base.Start();

        m_playerView.PlayerInput.PlayerToggledInventoryMenu.AddListener(TogglePlayerIntoAndFromCrouchPosition);
        m_playerView.PlayerInput.PlayerToggledInventoryMenu.AddListener(ToggleMovementState);
    }

    // Update is called once per frame
    void Update ()
    {
        Move();
	}

    void Move()
    {
        if (movementState != MovementState.Free)
            return;

        m_playerView.PlayerAnimController.SetBool("isCrouching", m_playerView.PlayerInput.IsCrouching);
        m_playerView.PlayerAnimController.SetFloat("Movement Speed", ReturnPlayerMovementSpeed());

        Vector3 rotation = new Vector3(m_playerView.PlayerInput.XInput, 0, m_playerView.PlayerInput.YInput);

        Quaternion newRotation = Quaternion.identity;

        if(rotation != Vector3.zero)
        {
            lastRotation = rotation;
            newRotation = Quaternion.LookRotation(rotation) * Quaternion.AngleAxis(45, Vector3.up);
        }
        else
        {
            if(lastRotation != Vector3.zero)
                newRotation = Quaternion.LookRotation(lastRotation) * Quaternion.AngleAxis(45, Vector3.up);
        }



        SetRotation(newRotation);        
    }

    public void InteractedWithResource(Resource resource)
    {
        movementState = MovementState.Frozen;
        m_playerView.PlayerAnimController.SetTrigger("Action");

        //switch (resource.associatedTool)
        //{
        //    case Resource.AssociatedTool.Axe:
        //        m_playerView.PlayerAnimController.SetTrigger("Chop");
        //        break;
        //    case Resource.AssociatedTool.Shovel:

        //        break;
        //}
    }

    public void UnFreezeMovement()
    {
        movementState = MovementState.Free;
    }

    /// <summary>
    /// Used when opening inventory
    /// </summary>
    ///
    private void TogglePlayerIntoAndFromCrouchPosition()
    {
        bool crouchingState = m_playerView.PlayerAnimController.GetBool("isCrouching");

        if(movementState == MovementState.Free)
        {
            if (!crouchingState)
                crouchingState = true;
        }
        else
        {
            crouchingState = false;
        }
      
        m_playerView.PlayerAnimController.SetFloat("Movement Speed", 0);
        m_playerView.PlayerAnimController.SetBool("isCrouching", crouchingState);
    }

    private void ToggleMovementState()
    {
        if (movementState == MovementState.Frozen)
            movementState = MovementState.Free;
        else
            movementState = MovementState.Frozen;
    }

    private float ReturnPlayerMovementSpeed()
    {
        float playerInput = Mathf.Abs(m_playerView.PlayerInput.XInput) + Mathf.Abs(m_playerView.PlayerInput.YInput);

        if(playerInput > 0)
        {
            if(m_playerView.PlayerInput.IsRunning)
            {
                return playerSprintSpeed;
            }
            else
            {
                return playerWalkSpeed;
            }
        }
        else
        {
            return 0;
        }

    }

    
}
