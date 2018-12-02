using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealthHandler : PlayerHandler
{
	private const float maxPlayerHealth = 100.0f;
	private float currentPlayerHealth;
	private const float playerHealthLossRate = 0.1f;

	public event Action<float,float> PlayerHealthUpdated;

	protected override void Start()
	{
		currentPlayerHealth = maxPlayerHealth;
		StartCoroutine(RemoveStandardPlayerEnergy());
	}

	IEnumerator RemoveStandardPlayerEnergy()
	{
		while(true)
		{
			yield return new WaitForSeconds(1.0f);
			RemovePlayerHealth(playerHealthLossRate);
		}
	}

	public void RenewPlayerHealth(float amount)
	{
		currentPlayerHealth += amount;
		if(currentPlayerHealth > maxPlayerHealth)
			currentPlayerHealth = maxPlayerHealth;

		if(PlayerHealthUpdated != null)
			PlayerHealthUpdated(currentPlayerHealth,maxPlayerHealth);
	}

	public void RemovePlayerHealth(float amount)
	{
		currentPlayerHealth -= amount;

		if(PlayerHealthUpdated != null)
			PlayerHealthUpdated(currentPlayerHealth,maxPlayerHealth);

		if(currentPlayerHealth <= 0)
		{
			Debug.Log("Player Collapsed");
		}
	}
	
	public float GetCurrentPlayerHealth()
	{
		return currentPlayerHealth;
	}

	public float GetMaxPlayerHealth()
	{
		return maxPlayerHealth;
	}

}
