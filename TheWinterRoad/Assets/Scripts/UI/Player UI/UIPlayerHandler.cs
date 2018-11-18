using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerHandler : MonoBehaviour {

	protected PlayerView playerView;

	public virtual void SetupPlayerUIHandler(PlayerView _playerView)
	{
		playerView = _playerView;
	}
}
