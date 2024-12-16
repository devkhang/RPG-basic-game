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
        SkillManager.Instance.Sword_Skill.DotActive(true);
    }

    public override void exit()
    {
        base.exit();
        player.StartCoroutine("BusyFor", .2f);
    }

    public override void Update()
    {
        base.Update();
        player.SetZeroVelocity();
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            stateMachine.changeState(player.ldieState);
        }
        Vector2 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(player.transform.position.x > MousePosition.x && player.facingDir == 1) {
            player.Flip();
        }else if(player.transform.position.x < MousePosition.x && player.facingDir == -1) { 
            player.Flip();
        }
    }
}
