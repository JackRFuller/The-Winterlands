using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputHandler : PlayerHandler
{
    private float m_XInput;
    private float m_YInput;

    [HideInInspector]
    public UnityEvent PlayerInteracted;
    [HideInInspector]
    public UnityEvent PlayerToggledInventoryMenu;

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

    private InputState inputState;
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
        }
      
        GetInventoryInput();
    }

    private void GetMovementInput()
    {
        m_XInput = Input.GetAxisRaw("Horizontal");
        m_YInput = Input.GetAxisRaw("Vertical");
    }

    private void GetInteractInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (PlayerInteracted != null)
                PlayerInteracted.Invoke();
        }
    }

    private void GetInventoryInput()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (PlayerToggledInventoryMenu != null)
                PlayerToggledInventoryMenu.Invoke();

            if (inputState == InputState.Free)
                inputState = InputState.Locked;
            else
                inputState = InputState.Free;
        }
    }

    public void LockCursorAndMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockCursorAndMouse()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
