using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : PlayerHandler
{
    private float m_XInput;
    private float m_YInput;

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
    }

    private void GetMovementInput()
    {
        m_XInput = Input.GetAxisRaw("Horizontal");
        m_YInput = Input.GetAxisRaw("Vertical");


    }
}
