using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterManager : MonoBehaviour
{
	private TimeManager timeManager;
	[SerializeField] private CharacterData[] characters;
	private List<ArrivingCharacter> charactersOfTheDay;

	[SerializeField] private Transform[] arrivalSpawnPoints; 

	private void Start()
	{
		
		timeManager = GameManager.Instance.TimeManager;		
		timeManager.NewDay += SetupListOfCharactersForTheDay;

		SetupListOfCharactersForTheDay();	
	}

	private void SetupListOfCharactersForTheDay()
	{
		charactersOfTheDay = new List<ArrivingCharacter>();

		for(int i = 0; i < characters.Length; i++)
		{
			if(characters[i].arrivalDay == timeManager.DayOfWeek)
			{
				ArrivingCharacter character = new ArrivingCharacter(characters[i],characters[i].minArrivalTime,characters[i].maxArrivalTime, ArrivingCharacter.RoadType.Arriving);

				charactersOfTheDay.Add(character);
			}
			if(characters[i].returnDay == timeManager.DayOfWeek)
			{
				ArrivingCharacter character = new ArrivingCharacter(characters[i],characters[i].minReturnTime,characters[i].maxReturnTime, ArrivingCharacter.RoadType.Returning);

				charactersOfTheDay.Add(character);
			}
		}
	}

	private void Update()
	{
		CheckToSpawnInCharacters();
	}

	private void CheckToSpawnInCharacters()
	{
		if(charactersOfTheDay.Count == 0)
			return;

		for(int i = 0; i < charactersOfTheDay.Count;i++)
		{			
			//Get Current Time in Float
			float currentHours = (float)timeManager.WorldTime.Hour;
			float currentMinutes = (float)timeManager.WorldTime.Minute / 60;

			float currentTime = currentHours + currentMinutes;

			if(currentTime >= charactersOfTheDay[i].timeToArrive)
			{
				Debug.Log("Spawn In " + charactersOfTheDay[i].characterData.characterName);
				
				Vector3 spawnPosition = arrivalSpawnPoints[UnityEngine.Random.Range(0,arrivalSpawnPoints.Length)].position;

				GameObject character = Instantiate(charactersOfTheDay[i].characterData.characterPrefab,spawnPosition,Quaternion.identity);


				charactersOfTheDay.Remove(charactersOfTheDay[i]);
			}
		}
	}
}

public class ArrivingCharacter
{
	public CharacterData characterData;
	public float timeToArrive;
	public ArrivingCharacter(CharacterData _characterData, float minTime, float maxTime, RoadType _roadType)
	{
		characterData = _characterData;
		timeToArrive = UnityEngine.Random.Range(minTime,maxTime);
		roadType = _roadType;
	}
	
	public RoadType roadType;
	public enum RoadType
	{
		Arriving,
		Returning,
	}
}
