using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCatchSwordState : playerState
{
    public playerCatchSwordState(playerStateMachine _stateMachine, player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void enter()
    {
        base.enter();


        if (player.transform.position.x >player.sword.transform.position.x  && player.facingDir == 1)
        {
            player.Flip();
        }
        else if (player.transform.position.x < player.sword.transform.position.x && player.facingDir == -1)
        {
            player.Flip();
        }
        rb.velocity = new Vector2(player.SwordReturningImpact*-player.facingDir,rb.velocity.y);
    }

    public override void exit()
    {
        base.exit();
        player.StartCoroutine("BusyFor", .1f);
    }

    public override void Update()
    {
        base.Update();
        if (triggerCall)
        {
            stateMachine.changeState(player.ldieState);
        }
    }

    // Start is called before the first frame update
}
