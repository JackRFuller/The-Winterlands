using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCanvasHandler : PlayerHandler
{
    [SerializeField]
    private UIInventoryHandler inventoryUIHandler;   
    [SerializeField]
    private UIInteractActionsHandler interactActionsHandler;
    [SerializeField]
    private UIDialogueBoxHandler dialogueBoxHandler;
    public UIInteractActionsHandler InteractActionsHandler
    {
        get
        {
            return interactActionsHandler;
        }
    }

    public UIInventoryHandler InventoryUIHandler
    {
        get
        {
            return inventoryUIHandler;
        }
    }

    [HideInInspector]
    public PlayerInMenu playerInMenuState = PlayerInMenu.Free;
    public enum PlayerInMenu
    {
        InMenu,
        Free,
    }

    public event Action PlayerOpenedMenu;
    public event Action PlayerClosedMenu;

    // Use this for initialization
    protected override void Start ()
    {
        base.Start();

        m_playerView.PlayerInput.ToggleInventory += ToggleInventory;
        inventoryUIHandler.SetupInventory(m_playerView);
    }

    private void ToggleInventory()
    {
        inventoryUIHandler.ToggleInventory();       
    }

    public void ToggleDialogueBox()
    {
        dialogueBoxHandler.ToggleDialogueBoxSHowing();
    }

    public void PlayerOpenedAMenu()
    {
        playerInMenuState = PlayerInMenu.InMenu;

        if (PlayerOpenedMenu != null)
            PlayerOpenedMenu();
    }

    public void PlayerClosedAMenu()
    {
        playerInMenuState = PlayerInMenu.Free;

        if (PlayerClosedMenu != null)
            PlayerClosedMenu();
    }
}
