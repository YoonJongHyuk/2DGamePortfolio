using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed = 0f; // 캐릭터의 이동 속도
    private SpriteRenderer playerSprteRenderer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerSprteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
            anim.SetBool("isWalk", true);
            playerSprteRenderer.flipX = true;
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("isWalk", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
            anim.SetBool("isWalk", true);
            playerSprteRenderer.flipX = false;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("isWalk", false);
        }
    }

}
