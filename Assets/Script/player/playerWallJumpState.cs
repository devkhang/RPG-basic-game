using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWallJumpState : playerState
{
    // Start is called before the first frame update
    public playerWallJumpState(playerStateMachine _stateMachine, player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void enter()
    {
        base.enter();
        stateTimer = .4f;
        player.SetVelocity(5*-player.facingDir,player.jumpForce);
    }

    public override void exit()
    {
        base.exit();
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0) {
            stateMachine.changeState(player.airState);
        }
        if (player.IsGroundDetected())
        {
            stateMachine.changeState(player.ldieState);
        }
    }
}
