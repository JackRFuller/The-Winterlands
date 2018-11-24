using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterManager : MonoBehaviour
{
	private TimeManager timeManager;
	[SerializeField] private CharacterData[] characters;

	private List<CharacterData> charactersOfTheDay;

	private void Start() {
		
		timeManager = GameManager.Instance.TimeManager;		
		timeManager.NewDay += SetupListOfCharactersForTheDay;

		SetupListOfCharactersForTheDay();	
	}

	private void SetupListOfCharactersForTheDay()
	{
		charactersOfTheDay = new List<CharacterData>();

		for(int i = 0; i < characters.Length; i++)
		{
			if(characters[i].arrivalDay == timeManager.DayOfWeek || characters[i].returnDay == timeManager.DayOfWeek)
			{
				charactersOfTheDay.Add(characters[i]);
			}
		}
	}

	private void Update()
	{
		CheckToSpawnInCharacters();
	}

	private void CheckToSpawnInCharacters()
	{
		for(int i = 0; i < charactersOfTheDay.Count;i++)
		{			
			//Get Current Time in Float
			float currentHours = (float)timeManager.WorldTime.Hour;
			float currentMinutes = (float)timeManager.WorldTime.Minute / 60;

			float currentTime = currentHours + currentMinutes;

			Debug.Log(currentTime);

			if(currentTime >= charactersOfTheDay[i].arrivalTime)
			{
				Debug.Log("Spawn In " + charactersOfTheDay[i].characterName);
			}
		}
	}

	

	
	
}
