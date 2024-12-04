using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAimState : playerState
{
    public playerAimState(playerStateMachine _stateMachine, player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
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
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            stateMachine.changeState(player.ldieState);
        }
    }
}
