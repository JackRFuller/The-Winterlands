using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputHandler : PlayerHandler
{
    private float m_XInput;
    private float m_YInput;
    private bool isCrouching;
    private bool isRunning;
    private bool canInteract = true;

    public event Action ToggleInventory;
    public event UnityAction<int> PlayerInteract;   

    public float XInput
    {
        get
        {
            return m_XInput;
        }
    }
    public float YInput
    {
        get
        {
            return m_YInput;
        }
    }
    public bool IsCrouching
    {
        get
        {
            return isCrouching;
        }        
    }
    public bool IsRunning
    {
        get
        {
            return isRunning;
        }       
    }    

    protected override void Start()
    {
        base.Start();
        LockCursorAndMouse();

        m_playerView.PlayerUIHandler.PlayerOpenedMenu += UnlockCursorAndMouse;       
        m_playerView.PlayerUIHandler.PlayerClosedMenu += LockCursorAndMouse;
    }

    private void Update()
    {        
        GetMovementInput();
        GetInteractInput();
        GetCrouchInput();
        GetSprintingInput();     
        
        GetInventoryInput();
        GetPauseInput();
    }

    #region Movement Input

    private void GetMovementInput()
    {
        m_XInput = Input.GetAxisRaw("Horizontal");
        m_YInput = Input.GetAxisRaw("Vertical");
    }

    private void GetCrouchInput()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = !isCrouching;
        }
    }

    private void GetSprintingInput()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    #endregion

    private void GetInventoryInput()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (ToggleInventory != null)
                ToggleInventory();
        }
    }

    private void GetInteractInput()
    {
        if (!canInteract)
            return;

        if(Input.GetMouseButtonDown(0))
        {
           Interact(0);
        }

        if(Input.GetMouseButtonDown(1))
        {
            Interact(1);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            Interact(2);
        }
    }

    private void Interact(int interactIndex)
    {
        if (PlayerInteract != null)
            PlayerInteract(interactIndex);
    }

    private void GetPauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameManager.Instance.ToggleGameState();
    }

    public void LockCursorAndMouse()
    {        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockCursorAndMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
