using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : IWeapon
{
    private Player player;
    IState prestate;

    public Energy(Player player)
    {
        this.player = player;
    }

    public void Attack(IState prestate)
    {
        this.prestate = prestate;
        player.anim.SetTrigger("SpecialAttack");
        GameManager.instance.StartCoroutine(RangeAttack());
    }

    IEnumerator RangeAttack()
    {
        yield return new WaitForSeconds(0.2f);

        player.rangeArea.gameObject.SetActive(true);
        if (player.spren.flipX == true)
        {
            player.rangeArea.GetComponent<SpriteRenderer>().flipX = true;
            player.rangeArea.transform.localPosition = new Vector3(-0.15f, 0, 0);
            player.rangeArea.GetComponent<Rigidbody2D>().velocity = Vector2.left * 5;
        }   
        else if (player.spren.flipX == false)
        {
            player.rangeArea.GetComponent<SpriteRenderer>().flipX = false;
            player.rangeArea.transform.localPosition = new Vector3(0.15f, 0, 0);
            player.rangeArea.GetComponent<Rigidbody2D>().velocity = Vector2.right * 5;

        }
        yield return new WaitForSeconds(0.5f);
        player.ChangeState(new IdleState(player));
    }
}
