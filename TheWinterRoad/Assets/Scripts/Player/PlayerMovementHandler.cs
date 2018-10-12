using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHandler : PlayerHandler
{
    private Animator animator;

    private Vector3 lastRotation;

    protected override void Start()
    {
        base.Start();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
        Move();
	}

    void Move()
    {
        m_playerView.PlayerAnimController.SetInteger("Speed", (int)(Mathf.Abs(m_playerView.PlayerInput.XInput) + Mathf.Abs(m_playerView.PlayerInput.YInput)));

        Vector3 rotation = new Vector3(m_playerView.PlayerInput.XInput, 0, m_playerView.PlayerInput.YInput);

        Quaternion newRotation = Quaternion.identity;

        if(rotation != Vector3.zero)
        {
            lastRotation = rotation;
            newRotation = Quaternion.LookRotation(rotation) * Quaternion.AngleAxis(45, Vector3.up);
        }
        else
        {
            if(lastRotation != Vector3.zero)
                newRotation = Quaternion.LookRotation(lastRotation) * Quaternion.AngleAxis(45, Vector3.up);
        }

        SetRotation(newRotation);
        
    }

    
}
