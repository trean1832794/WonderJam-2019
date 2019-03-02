using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : StateMachineBehaviour
{

    private bool teleported = false;
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (stateInfo.normalizedTime >= 0.1714f && !teleported)
        {

            //teleport players
            GameObject.Find("Event").GetComponent<PlayerSwap>().Activate();
            teleported = true;

        }

        if (stateInfo.normalizedTime >= 0.6f)
        {

            Destroy(animator.gameObject);

        }

    }

}
