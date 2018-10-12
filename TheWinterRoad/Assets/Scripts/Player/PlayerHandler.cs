using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerView))]
public class PlayerHandler : Entity
{
    protected PlayerView m_playerView;

    protected virtual void Start()
    {
        m_playerView = GetComponent<PlayerView>();
    }
	
}
