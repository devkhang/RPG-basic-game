using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : entity
{
    [Header("move info")]
    public float moveSpeed = 5f;
    public float idleTime = 2f;


    protected enemyStateMachine stateMachine { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new enemyStateMachine();
    }
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }
}
