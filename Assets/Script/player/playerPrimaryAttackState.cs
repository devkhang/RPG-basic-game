using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPrimaryAttackState : playerState
{
    // Start is called before the first frame update
    private int comboCounter;
    private float comboWindowTime = 2;
    private float lastTimeAttack;
    public playerPrimaryAttackState(playerStateMachine _stateMachine, player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void enter()
    {
        base.enter();

        if(comboCounter > 2||Time.time > lastTimeAttack + comboWindowTime)
        {
            comboCounter = 0;
        }
        player.anim.SetInteger("comboCounter",comboCounter);

        float attackDir = player.facingDir;
        if (xinput != 0)
        {
            attackDir = xinput;
        }

        player.SetVelocity(player.attackMovement[comboCounter].x * attackDir, player.attackMovement[comboCounter].y);
        stateTimer = 0.1f;
    }

    public override void exit()
    {
        base.exit();
        player.StartCoroutine(player.BusyFor(0.15f));
        comboCounter++;
        lastTimeAttack = Time.time;
    }

    public override void Update()
    {
        base.Update();
        if(stateTimer < 0)
        {
            player.SetZeroVelocity();
        }

        if (triggerCall)
        {
            stateMachine.changeState(player.ldieState);
        }
    }
}
