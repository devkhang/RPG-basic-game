using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySkeleton : enemy
{
    #region State
    public enemyIdleState enemyIdleState {  get; private set; }
    public enemyMoveState moveState { get; private set; }
    #endregion
    protected override void Awake()
    {
        base.Awake();
        enemyIdleState = new enemyIdleState(this,stateMachine,"Idle",this);
        moveState = new enemyMoveState(this,stateMachine,"Move",this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.init(enemyIdleState);
    }

    protected override void Update()
    {
        base.Update();
    }
}
