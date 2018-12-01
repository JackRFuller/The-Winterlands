using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHealthBar : UIPlayerHandler
{	
	

	[Header("UI Elements")]
	[SerializeField]
	private Image healthBarImage;

	public override void SetupPlayerUIHandler(PlayerView _playerView)
	{
		base.SetupPlayerUIHandler(_playerView);
		playerView.PlayerHealthHandler.PlayerHealthUpdated += UpdatePlayerHealthBar;	
	}

	private void UpdatePlayerHealthBar(float playerHealth, float maxPlayerHealth)
	{
		float fillAmount = playerHealth / maxPlayerHealth;
		healthBarImage.fillAmount = fillAmount;
	}
}
