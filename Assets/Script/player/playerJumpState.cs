using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJumpState : playerState
{
    // Start is called before the first frame update
    public playerJumpState(playerStateMachine _stateMachine, player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void enter()
    {
        base.enter();
        rb.velocity = new Vector2(rb.velocity.x, player.jumpForce);
    }

    public override void exit()
    {
        base.exit();
    }

    public override void Update()
    {
        base.Update();
        if(rb.velocity.y < 0&&!player.IsGroundDetected())
        {
            player.stateMachine.changeState(player.airState);
        }
    }
}
