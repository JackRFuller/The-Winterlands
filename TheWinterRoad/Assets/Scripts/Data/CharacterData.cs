﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Data", menuName = "Data/Character", order = 1)]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public GameObject characterPrefab;
}
