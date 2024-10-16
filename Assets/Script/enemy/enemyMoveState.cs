using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMoveState : enemyState
{
    // Start is called before the first frame update
    private enemySkeleton enemy;
    public enemyMoveState()
    {
    }

    public enemyMoveState(enemy _enemyBase, enemyStateMachine stateMachine, string animBoolName,enemySkeleton _enemy) : base(_enemyBase, stateMachine, animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        enemy.SetVelocity(enemy.moveSpeed * enemy.facingDir,enemy.rb.velocity.y);

        
        if(!enemy.IsGroundDetected()||enemy.IsWallDetected()) {
            enemy.Flip();
            stateMachine.change(enemy.enemyIdleState);
        }
    }
}
