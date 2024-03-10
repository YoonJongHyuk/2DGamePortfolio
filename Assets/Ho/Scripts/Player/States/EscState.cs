using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscState : IState
{
    private Player player;
    public EscState(Player player)
    { 
        this.player = player; 
    }

    public void EnterState()
    {
        player.GetComponent<Attack>().enabled = false;
    }

    public void ExitState()
    {
        player.GetComponent<Attack>().enabled = true;
    }

    public void UpdateState()
    {
        
    }
}
