using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanvasHandler : PlayerHandler
{
    [SerializeField]
    private UIPlayerBackpackUIHandler backpackUIHandler;
    [SerializeField]
    private UIPlayerToolbeltHandler toolBeltUIHandler;

	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
        m_playerView.PlayerInput.PlayerToggledInventoryMenu.AddListener(ToggleInventory);
    }

    private void ToggleInventory()
    {
        backpackUIHandler.ToggleInventory();
        toolBeltUIHandler.ToggleInventory();
    }
}
