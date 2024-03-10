using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : IWeapon
{
    private Player player;
    IState prestate;
    public Sword(Player player) 
    {  
        this.player = player; 
    }

    public void Attack(IState prestate)
    {
        this.prestate = prestate;
        if (player.GetComponentInChildren<MeleeArea>(true) == null) return;
        player.anim.SetTrigger("doAttack");
        if (!player.anim.GetBool("continueAttack"))
            GameManager.instance.StartCoroutine(MeleeAttack());
        else
            GameManager.instance.StartCoroutine(MeleeAttackContinue());
    }

    IEnumerator MeleeAttack()
    {
        if (player.spren.flipX == true)
            player.meleeArea.transform.localPosition = new Vector3(-0.7f, 0, 0);
        else if (player.spren.flipX == false)
            player.meleeArea.transform.localPosition = new Vector3(0.7f, 0, 0);
        player.meleeArea.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        player.meleeArea.gameObject.SetActive(false);
        player.anim.SetBool("continueAttack", true);
        if (!(prestate is JumpAttackState))
            player.ChangeState(new IdleState(player));
        yield return new WaitForSeconds(seconds: 0.2f);
        player.anim.SetBool("continueAttack", false);
    }

    IEnumerator MeleeAttackContinue()
    {
        if (player.spren.flipX == true)
            player.meleeArea.transform.localPosition = new Vector3(-0.7f, 0, 0);
        else if (player.spren.flipX == false)
            player.meleeArea.transform.localPosition = new Vector3(0.7f, 0, 0);
        player.meleeArea.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        player.meleeArea.gameObject.SetActive(false);
        if (!(prestate is JumpAttackState))
            player.ChangeState(new IdleState(player));
        player.ChangeState(new IdleState(player));
        player.anim.SetBool("continueAttack", false);
    }
}
