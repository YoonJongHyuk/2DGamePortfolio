using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : IState
{
    private Player player;
    bool isDoubleJumped;
    public JumpingState(Player player)
    {
        this.player = player;
    }

    public void EnterState()
    {
        player.rigid.AddForce(Vector2.up * 4, ForceMode2D.Impulse);
        player.anim.SetTrigger("doJump");
    }

    public void ExitState()
    {
        isDoubleJumped = false;
        player.anim.SetBool("isWalk", false);
    }

    public void UpdateState()
    {
        player.move.PlayerJumpMove();
        if (Input.GetKeyDown(KeyCode.Space) && !isDoubleJumped)
        {
            player.rigid.AddForce(Vector2.up * 4, ForceMode2D.Impulse);
            player.anim.SetTrigger("doJump");
            player.anim.SetBool("isWalk", true);
            isDoubleJumped = true;
        }
            

    }
}
