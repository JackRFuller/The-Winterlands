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
    
    private void Update()
    {
        GetMovementInput();
        GetInteractInput();
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
}
