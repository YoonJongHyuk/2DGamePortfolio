using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Player player;
    private Rigidbody2D rigid;
    float hMove;

    void Start()
    {
        player = GetComponent<Player>();
        rigid = GetComponent<Rigidbody2D>();
    }

    public void PlayerMove()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            player.speed = 5;
        else
            player.speed = 3;
      

        hMove = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(hMove * player.speed, rigid.velocity.y);
    }

    public void PlayerJumpMove()
    {
        hMove = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(hMove * player.speed, rigid.velocity.y);
    }

    public void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.ChangeState(new JumpingState(player));
        }
    }
}
