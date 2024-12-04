using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySkeleton : enemy
{
    #region State
    public skeletonIdleState enemyIdleState {  get; private set; }
    public skeletonMoveState moveState { get; private set; }
    public skeletonBattleState battleState { get; private set; }
    public skeletonAttackState attackState { get; private set; }
    public skeletonStunState stunState { get; private set; }
    #endregion
    protected override void Awake()
    {
        base.Awake();
        enemyIdleState = new skeletonIdleState(this,stateMachine,"Idle",this);
        moveState = new skeletonMoveState(this,stateMachine,"Move",this);
        battleState = new skeletonBattleState(this, stateMachine, "Move", this);
        attackState = new skeletonAttackState(this, stateMachine, "Attack", this);
        stunState = new skeletonStunState(this, stateMachine, "Stunned", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.init(enemyIdleState);
    }

    protected override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.U))
        {
            stateMachine.change(stunState);
        }
    }
    public override bool canBeStunned()
    {
        if(base.canBeStunned()){
            stateMachine.change(stunState);
            return true;
        }
        return false;
    }
}
