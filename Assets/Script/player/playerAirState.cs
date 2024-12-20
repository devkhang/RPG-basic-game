using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAirState : playerState
{
    // Start is called before the first frame update
    public playerAirState(playerStateMachine _stateMachine, player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void enter()
    {
        base.enter();
    }

    public override void exit()
    {
        base.exit();
    }

    public override void Update()
    {
        base.Update();
        try
        {
            if (player.IsWallDetected() && !player.collider1.IsTouching(player.GetComponent<Collider2D>()))
            {
                stateMachine.changeState(player.WallSlideState);
            }
        }catch(System.Exception e)
        {
            Debug.Log("nothing");
        }

        if (player.IsGroundDetected())
        {
            stateMachine.changeState(player.ldieState);
        }
        if (xinput != 0)
        {
            player.SetVelocity(xinput * .8f * player.movespeed, rb.velocity.y);
        }
    }
}
