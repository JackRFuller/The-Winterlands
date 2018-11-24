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

    public TimePeriods.DaysOfWeek arrivalDay;
    public TimePeriods.DaysOfWeek returnDay;         
    [HideInInspector] public float minArrivalTime;
    [HideInInspector] public float maxArrivalTime;

    [HideInInspector] public float minReturnTime;
    [HideInInspector] public float maxReturnTime;


    public void SetArrivalTimeLimits(float min, float max)
    {
        minArrivalTime = min;
        maxArrivalTime = max;
    }

    public void SetReturnTimeLimits(float min, float max)
    {
        minReturnTime = min;
        maxReturnTime = max;
    }
}
