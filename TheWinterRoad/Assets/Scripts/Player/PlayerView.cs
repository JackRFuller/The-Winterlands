using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : Entity
{
    private Animator playerAnimController;
    private BoxCollider playerCollider;
    private PlayerInputHandler playerInput;
    private PlayerMovementHandler playerMovement;

    public BoxCollider PlayerCollider
    {
        get
        {
            return playerCollider;
        }
    }
    public Animator PlayerAnimController
    {
        get
        {
            return playerAnimController;
        }
    }
    public PlayerInputHandler PlayerInput
    {
        get
        {
            return playerInput;
        }
    }
    public PlayerMovementHandler PlayerMovement
    {
        get
        {
            return playerMovement;
        }
    }

    

    private void Awake()
    {
        playerAnimController = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider>();

        playerInput = GetComponent<PlayerInputHandler>();
        playerMovement = GetComponent<PlayerMovementHandler>();
    }
}
