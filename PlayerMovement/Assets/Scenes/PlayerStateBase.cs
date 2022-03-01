using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateBase : StateMachineBehaviour
{
    private Player player;

    public Player GetPlayerControl(Animator animator)
    {
        if (player == null)
        {
            player = animator.GetComponentInParent<Player>();
            return player;
        }
        return player;
    }
}
