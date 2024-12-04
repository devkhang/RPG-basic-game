using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : playerState
{
    // Start is called before the first frame update
    public PlayerDashState(playerStateMachine _stateMachine, player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void enter()
    {
        base.enter();
        player.skill.Clone_Skill.Create_Clone(player.transform);
        stateTimer = player.dashDuration;
    }

    public override void exit()
    {
        base.exit();
        player.SetVelocity(0,rb.velocity.y);
    }

    public override void Update()
    {
        base.Update();
        player.SetVelocity(player.dashSpeed * player.dashDir,0);
        if(!player.IsGroundDetected()&&player.IsWallDetected()) {
            stateMachine.changeState(player.WallSlideState);
        }

        if(stateTimer < 0) {
            stateMachine.changeState(player.ldieState);
        }
    }
}
