using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLdieState : playerGroundState
{
    // Start is called before the first frame update
    public playerLdieState(playerStateMachine _stateMachine, player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {

    }

    public override void enter()
    {
        base.enter();

        rb.velocity = new Vector2(0, 0);
    }

    public override void exit()
    {
        base.exit();
    }

    public override void Update()
    {
        base.Update();
        if (xinput!=0&&!player.IsBusy)
        {
            player.stateMachine.changeState(player.moveState);
        }
    }
}
