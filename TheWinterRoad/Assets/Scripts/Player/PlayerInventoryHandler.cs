using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryHandler : PlayerHandler
{
    [SerializeField]
    private List<Tool> toolBelt;

    public bool CheckPlayerHasTool(string toolName)
    {
        for (int i = 0; i < toolBelt.Count; i++)
        {
            if(toolName == toolBelt[i].toolName)
            {
                return true;                
            }
        }

        return false;
    }
	
}
