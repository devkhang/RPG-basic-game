using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCounterAttack : playerState
{
    // Start is called before the first frame update
    public playerCounterAttack(playerStateMachine _stateMachine, player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void enter()
    {
        base.enter();
        stateTimer = player.counterAttackDuration;
        player.anim.SetBool("successfullCounterAttack",false);
    }

    public override void exit()
    {
        base.exit();
    }

    public override void Update()
    {
        base.Update();
        player.SetZeroVelocity();
        Collider2D[] hits = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);
        foreach (Collider2D hit in hits)
        {
            if (hit.GetComponent<enemy>() != null)
            {
                if(hit.GetComponent<enemy>().canBeStunned()) {
                    stateTimer = 10;
                    player.anim.SetBool("successfullCounterAttack", true);
                }
            }
        }

        if(stateTimer < 0 || triggerCall)
        {
            stateMachine.changeState(player.ldieState);
        }
    }
}
