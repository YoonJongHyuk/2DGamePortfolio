using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Player player;
    private void Awake()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !(player.currentState is AttackState) && !(player.currentState is JumpingState) && !(player.currentState is JumpAttackState))
            player.ChangeState(new AttackState(player));
        else if (Input.GetMouseButtonDown(0) && !(player.currentState is AttackState) && (player.currentState is JumpingState) && !(player.currentState is JumpAttackState))
            player.ChangeState(new JumpAttackState(player));
    }
}
