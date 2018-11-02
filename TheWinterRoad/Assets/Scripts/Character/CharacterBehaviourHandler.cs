using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviourHandler : Entity
{
    protected CharacterView characterView;

	protected virtual void Start()
    {
        characterView = GetComponent<CharacterView>();
    }
}
