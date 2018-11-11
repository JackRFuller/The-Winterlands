using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterView : Entity
{
    //Script Components
    [SerializeField]
    private CharacterData characterData;

    //Unity Components
    private NavMeshAgent navMeshAgent;
    
    public CharacterData CharacterData
    {
        get
        {
            return characterData;
        }
    }
    public NavMeshAgent NavMeshAgent
    {
        get
        {
            return navMeshAgent;
        }
    }
}
