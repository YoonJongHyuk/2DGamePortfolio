using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private Player player;
    public IdleState(Player player)
    {
        this.player = player; 
    }

    public void EnterState()
    {
        
    }

    public void ExitState()
    {
        
    }

    public void UpdateState()
    {
        player.move.PlayerMove();
        switch(Mathf.Abs(player.rigid.velocity.x))
        {
            case 0:
                player.ChangeState(new IdleState(player));
                break;
            case 3:
                player.ChangeState(new WalkingState(player)); 
                break;
            case 5:
                player.ChangeState(new RunningState(player));
                break;
        }
        player.move.PlayerJump();
        
    }
}
