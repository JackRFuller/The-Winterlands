using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue",menuName = "Data/Dialogue/Dialogue", order = 1)]
public class DialogueData : ScriptableObject
{
    [TextArea]
    public string statement;

    private const int responseSizeMax = 4;
    [TextArea]
    public string[] playerResponses = new string[responseSizeMax];

    public DialogueData[] linkedResponses = new DialogueData[responseSizeMax];
    

    void OnValidate()
    {
        if(playerResponses.Length > responseSizeMax - 1)
        {            
            System.Array.Resize(ref playerResponses, responseSizeMax);
        }

        if(linkedResponses.Length != playerResponses.Length)
        {
            System.Array.Resize(ref linkedResponses, playerResponses.Length);
        }
    }

}
