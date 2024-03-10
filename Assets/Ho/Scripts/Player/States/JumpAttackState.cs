using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttackState : IState
{
    private Player player;
    private Vector3 jumpVec;
    public JumpAttackState(Player player)
    { 
        this.player = player; 
    }

    public void EnterState()
    {
        player.currentWeapon.Attack(this);
        jumpVec = player.rigid.velocity;
        player.anim.SetBool("isWalk", true);
    }

    public void ExitState()
    {
        player.anim.SetBool("isWalk", false);
    }

    public void UpdateState()
    {
        player.rigid.velocity = new Vector3(jumpVec.x, player.rigid.velocity.y);
    }
}
