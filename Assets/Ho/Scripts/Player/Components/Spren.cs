using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spren : MonoBehaviour
{
    Player player;
    SpriteRenderer spren;
    Rigidbody2D rigid;
    Vector3 mousePoint;

    void Start()
    {
        player = GetComponent<Player>();
        rigid = GetComponent<Rigidbody2D>();
        spren = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    void LateUpdate()
    {
        if (rigid.velocity.x < 0)
            spren.flipX = true;
        else if (rigid.velocity.x > 0)
            spren.flipX = false;

        if (player.currentState is IdleState)
            if (player.transform.position.x - mousePoint.x < 0)
                spren.flipX = false;
            else
                spren.flipX = true;
    }
}
