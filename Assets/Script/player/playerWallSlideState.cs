using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWallSlideState : playerState
{
    // Start is called before the first frame update
    public playerWallSlideState(playerStateMachine _stateMachine, player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.changeState(player.wallJumpState);
            return;
        }

        if(yinput < 0)
        {
            player.SetVelocity(0, yinput*1.2f);
        }
        else
        {
            player.SetVelocity(0, yinput * 0.7f);
        }
        if(xinput != 0 && player.facingDir != xinput)
        {
            stateMachine.changeState(player.ldieState);
        }
        if(player.IsGroundDetected()) {
            stateMachine.changeState(player.ldieState);
        }
    }
}
