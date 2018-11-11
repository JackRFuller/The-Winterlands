using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue Tree", menuName = "Data/Dialogue/Dialogue Tree", order =1)]
public class DialogueTreeData : ScriptableObject
{
    public DialogueData openingStatement;

    public List<DialogueData> optionalDialogue;
	
}
