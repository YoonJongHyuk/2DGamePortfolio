using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            player.ChangeWeapon(new Sword(player));
        else if(Input.GetKeyDown(KeyCode.Alpha2))
            player.ChangeWeapon(new Energy(player));
    }
}
