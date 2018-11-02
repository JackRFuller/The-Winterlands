using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanvasHandler : PlayerHandler
{
    [SerializeField]
    private UIInventoryHandler inventoryUIHandler;
    [SerializeField]
    private UIInteractActionsHandler interactActionsHandler;
    public UIInteractActionsHandler InteractActionsHandler
    {
        get
        {
            return interactActionsHandler;
        }
    }

    // Use this for initialization
    protected override void Start ()
    {
        base.Start();
        m_playerView.PlayerInput.PlayerToggledInventoryMenu.AddListener(ToggleInventory);
        inventoryUIHandler.SetupInventory(m_playerView);
    }

    private void ToggleInventory()
    {
        inventoryUIHandler.ToggleInventory();       
    }
}
