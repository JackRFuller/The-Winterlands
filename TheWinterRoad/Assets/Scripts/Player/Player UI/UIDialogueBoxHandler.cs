using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDialogueBoxHandler : Entity
{
    private Animator dialogueBoxAnimController;

    private void Start()
    {
        dialogueBoxAnimController = GetComponent<Animator>();
    }

    public void ToggleDialogueBoxSHowing()
    {
        dialogueBoxAnimController.SetBool("isShowing", !dialogueBoxAnimController.GetBool("isShowing"));
    }
}
