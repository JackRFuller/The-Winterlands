using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : Entity
{
    private Animator playerAnimController;
    private BoxCollider playerCollider;

    private PlayerInputHandler playerInput;
    private PlayerInventoryHandler playerInventory;
    private PlayerMovementHandler playerMovement;
    private PlayerInteractionHandler playerInteraction;
    private PlayerCanvasHandler playerUIHandler;

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
    public PlayerInventoryHandler PlayerInventory
    {
        get
        {
            return playerInventory;
        }
    }
    public PlayerInteractionHandler PlayerInteraction
    {
        get
        {
            return playerInteraction;
        }
    }
    public PlayerCanvasHandler PlayerUIHandler
    {
        get
        {
            return playerUIHandler;
        }
    }

    private void Awake()
    {
        playerAnimController = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider>();

        playerInput = GetComponent<PlayerInputHandler>();
        playerMovement = GetComponent<PlayerMovementHandler>();
        playerInventory = GetComponent<PlayerInventoryHandler>();
        playerInteraction = GetComponent<PlayerInteractionHandler>();
        playerUIHandler = GetComponent<PlayerCanvasHandler>();
    }
}
