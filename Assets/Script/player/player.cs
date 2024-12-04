using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class player : entity
{
    public Collider2D collider1 = null;
    private bool isOnOneWayPlatform;
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
    public float dashDir { get; private set; }

    public SkillManager skill;

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
    public playerCounterAttack playerCounterAttack { get; private set; }
    public playerAimState playerAimState { get; private set; }
    public playerCatchSwordState playerCatchSword { get; private set; }
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
        playerCounterAttack = new playerCounterAttack(stateMachine, this, "counterAttack");
        playerAimState = new playerAimState(stateMachine, this, "AimSword");
        playerCatchSword = new playerCatchSwordState(stateMachine, this, "CatchSword");
    }

    public bool IsOnOneWayPlatform()
    {
        return isOnOneWayPlatform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            isOnOneWayPlatform = true;
            collider1 = collision.gameObject.GetComponent<Collider2D>();
        }
        else
        {
            isOnOneWayPlatform = false;
            collider1 = collision.gameObject.GetComponent<Collider2D>();
            // Không phải One-Way Platform
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            isOnOneWayPlatform = false;
            collider1 = null;
        }
    }
    protected override void Start()
    {
        base.Start();
        skill = SkillManager.Instance;
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
        
        if(IsWallDetected())
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)&&SkillManager.Instance.Dash_Skill.CanUseSkill())
        {
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
