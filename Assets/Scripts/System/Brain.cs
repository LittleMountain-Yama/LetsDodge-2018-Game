using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain
{
    Player _p;

    public Brain(Player player)
    {
        _p = player;
    }
    
    public void ListenerKey()
    {
        if (_p.isCrouching != true && _p.isDamaged != true && _p.isDefault != true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _p.Jump();
                _p.isJumping = true;
            }
        }

        if (Input.GetAxis("Horizontal") != 0)
            if (_p.isCrouching != true && _p.isDamaged != true && _p.isDashing != true)
               _p.Move(Input.GetAxis("Horizontal"));
    }
}
