using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Data", menuName = "Data/Character", order = 1)]
public class CharacterData : ScriptableObject
{
    public GameObject characterPrefab;
    [Space(10)]
    public string characterAlias;
    public string characterName;

    public InteractableItemData characterInteractActions;
    public DialogueTreeData characterDialogueTree;

}
