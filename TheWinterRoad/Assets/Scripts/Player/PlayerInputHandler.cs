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
    
    [HideInInspector]
    public UnityEvent PlayerToggledInventoryMenu;

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

    private InputState inputState = InputState.Free;
    private enum InputState
    {
        Free,
        Locked,
    }

    protected override void Start()
    {
        base.Start();
        LockCursorAndMouse();
    }

    private void Update()
    {
        if(inputState == InputState.Free)
        {
            GetMovementInput();
            GetInteractInput();
            GetCrouchInput();
            GetSprintingInput();
        }
      
        GetInventoryInput();
    }

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

    private void GetInteractInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PlayerInteract(0);
        }

        if(Input.GetMouseButtonDown(1))
        {
            PlayerInteract(1);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            PlayerInteract(2);
        }
    }

    private void GetInventoryInput()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (inputState == InputState.Free)
            {
                inputState = InputState.Locked;
                UnlockCursorAndMouse();
            }               
            else
            {
                inputState = InputState.Free;
                LockCursorAndMouse();
            }
               

            if (PlayerToggledInventoryMenu != null)
                PlayerToggledInventoryMenu.Invoke();
        }
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
