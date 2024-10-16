using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGroundState : playerState
{
    // Start is called before the first frame update
    public playerGroundState(playerStateMachine _stateMachine, player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
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

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            stateMachine.changeState(player.playerPrimaryAttack);
        }

        if(!player.IsGroundDetected())
        {
            stateMachine.changeState(player.airState);
        }

        if(Input.GetKeyDown(KeyCode.Space) && player.IsGroundDetected()) {
            stateMachine.changeState(player.jumpState);
        }
    }
}