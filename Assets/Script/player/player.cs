using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class player : entity
{
    [Header("Attack details")]
    public Vector2[] attackMovement;
    public float counterAttackDuration = .2f;
    public bool IsBusy { get; private set; }
    [Header("move info")]
    public float movespeed = 8f;
    public float jumpForce = 12f;

    [Header("dash info")]
    public float dashDuration;
    public float dashSpeed;
    [SerializeField] private float dashCoolDown;
    private float dashUsageTimer = 1;
    public float dashDir { get; private set; }

#region state
    public playerStateMachine stateMachine { get; private set; }
    public playerLdieState ldieState { get; private set; }
    public playerMoveState moveState { get; private set; }

    public playerJumpState jumpState { get; private set; } 
    public playerAirState airState { get; private set; }

    public PlayerDashState dashState { get; private set; }
    public playerWallSlideState WallSlideState { get; private set; }   
    public playerWallJumpState wallJumpState { get; private set; } 

    public playerPrimaryAttackState playerPrimaryAttack { get; private set; }
    // Start is called before the first frame update

    #endregion state
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new playerStateMachine();
        ldieState = new playerLdieState(stateMachine, this, "Idle");
        moveState = new playerMoveState(stateMachine, this, "Move");
        jumpState = new playerJumpState(stateMachine, this, "Jump");
        airState  = new playerAirState(stateMachine, this, "Jump");
        dashState = new PlayerDashState(stateMachine, this, "Dash");
        WallSlideState = new playerWallSlideState(stateMachine, this, "Slide");
        wallJumpState = new playerWallJumpState(stateMachine, this, "Jump");
        playerPrimaryAttack = new playerPrimaryAttackState(stateMachine, this, "Attack");
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.init(ldieState);
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
        checkDashAbility();
    }
    public IEnumerator BusyFor(float _second)
    {
        IsBusy = true;
        yield return new WaitForSeconds(_second);
        IsBusy = false;
    }
    public void checkDashAbility()
    {
        dashUsageTimer -= Time.deltaTime;
        if(IsWallDetected())
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)&&dashUsageTimer<0)
        {
            dashUsageTimer = dashCoolDown;
            dashDir = Input.GetAxisRaw("Horizontal");
            if(dashDir == 0)
            {
                dashDir = facingDir;
            }
            stateMachine.changeState(this.dashState);
        }
    }

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();
}
