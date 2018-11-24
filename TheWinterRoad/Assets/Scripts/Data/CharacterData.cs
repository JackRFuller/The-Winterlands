using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Character Data", menuName = "Data/Character", order = 1)]
public class CharacterData : ScriptableObject
{
    public GameObject characterPrefab;
    [Space(10)]
    public string characterAlias;
    public string characterName;

    public InteractableItemData characterInteractActions;
    public DialogueTreeData characterDialogueTree;

    [Header("Arrival Schedule")]
    public TimePeriods.DaysOfWeek arrivalDay;
    public TimePeriods.DayPeriods arrivalPeriod;
    [Tooltip("Time is in 24hrs - 11:30 = 11.5")]
    public float arrivalTime;
    public float ArrivalTimeInWorldTime
    {
        get
        {
            return arrivalTime * 3600 * 5;
        }
    }

    [Header("Return Schedule")]
    public TimePeriods.DaysOfWeek returnDay;
    public TimePeriods.DayPeriods returnPeriod;
    [Tooltip("Time is in 24hrs - 11:30 = 11.5")]
    public float returnTime;
    public float ReturnTimeInWorldTime
    {
        get
        {
            return returnTime * 3600 * 5;
        }
    }
    
    public DateTime arrivalDateTime;
}
