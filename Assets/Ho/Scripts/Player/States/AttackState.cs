using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    private Player player;
    public AttackState(Player player)
    {
        this.player = player;
    }

    public void EnterState()
    {
        player.rigid.velocity = Vector3.zero;
        player.currentWeapon.Attack(this);
    }

    public void ExitState()
    {
       
    }

    public void UpdateState()
    {
        if (Input.GetMouseButtonDown(0))
            player.anim.SetBool("continueAttack", true);

    }

    
}
