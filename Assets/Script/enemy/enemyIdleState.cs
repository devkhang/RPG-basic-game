using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyIdleState : enemyState
{
    // Start is called before the first frame update
    private enemySkeleton enemy;
    public enemyIdleState()
    {
    }

    public enemyIdleState(enemy _enemyBase, enemyStateMachine stateMachine, string animBoolName , enemySkeleton _enemy) : base(_enemyBase, stateMachine, animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(stateTimer < 0f)
        {
            stateMachine.change(enemy.moveState);
        }
    }
}
