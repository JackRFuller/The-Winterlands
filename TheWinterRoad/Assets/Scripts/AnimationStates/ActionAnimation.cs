using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAnimation : StateMachineBehaviour
{
    private PlayerView playerView;

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (playerView == null)
            playerView = animator.gameObject.GetComponent<PlayerView>();

        playerView.PlayerMovement.UnFreezeMovement();

        animator.ResetTrigger("Action");
    }
}
