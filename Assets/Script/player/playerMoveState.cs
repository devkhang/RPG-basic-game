using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoveState : playerGroundState
{
    // Start is called before the first frame update
    public playerMoveState(playerStateMachine _stateMachine, player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
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
        if (player.IsWallDetected())
        {
            stateMachine.changeState(player.ldieState);
        }

        player.SetVelocity(xinput * player.movespeed, rb.velocity.y);


        if(xinput==0) {
            player.stateMachine.changeState(player.ldieState);
        }
    }
}
