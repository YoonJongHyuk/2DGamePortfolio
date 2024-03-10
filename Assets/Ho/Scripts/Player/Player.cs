using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Move move;
    public Rigidbody2D rigid;
    public CapsuleCollider2D coll;
    public Animator anim;
    public MeleeArea meleeArea;
    public RangeArea rangeArea;
    public Sheild sheild;
    public SpriteRenderer spren;

    public float speed;


    public IState currentState;
    public IWeapon currentWeapon;

    public void ChangeState(IState newstate)
    {
        currentState.ExitState();
        currentState = newstate;
        currentState.EnterState();
    }

    public void ChangeWeapon(IWeapon newweapon)
    {
        currentWeapon = newweapon;
    }

    private void Awake()
    {
        move = GetComponent<Move>();
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        spren = GetComponent<SpriteRenderer>();
        meleeArea = GetComponentInChildren<MeleeArea>(true);
        rangeArea = GetComponentInChildren<RangeArea>(true);
        sheild = GetComponentInChildren<Sheild>(true);

        currentState = new IdleState(this);
        currentState.EnterState();
        currentWeapon = new Sword(this);
    }

    void Update()
    {
        currentState.UpdateState();
        
        if(Input.GetMouseButtonDown(1))
            sheild.gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
            ChangeState(new IdleState(this));
    }
}
