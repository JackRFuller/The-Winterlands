using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterView))]
public class CharacterInteractHandler : Interactable
{
    private CharacterView characterView;

    protected override void Start()
    {
        base.Start();

        characterView = GetComponent<CharacterView>(); 
        interactableData = characterView.CharacterData.characterInteractActions;
    }

    public override void InteractOne()
    {
        playerView.PlayerUIHandler.ToggleDialogueBox();
    }
}
