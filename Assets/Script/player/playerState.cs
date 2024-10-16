using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerState
{
    // Start is called before the first frame update
    protected playerStateMachine stateMachine;
    protected player player;
    protected float xinput;
    protected float yinput;
    protected Rigidbody2D rb;
    protected bool triggerCall;

    protected float stateTimer;

    private string animBoolName;
    public playerState(playerStateMachine _stateMachine,player _player,string _animBoolName)
    {
        this.stateMachine = _stateMachine;
        this.player = _player;
        this.animBoolName = _animBoolName;
    }
    public virtual void enter()
    {
        player.anim.SetBool(animBoolName, true);
        rb = player.rb;
        triggerCall = false;
    }
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        xinput = Input.GetAxisRaw("Horizontal");
        yinput = Input.GetAxisRaw("Vertical");

        player.anim.SetFloat("y_velocity", rb.velocity.y);
    }
    public virtual void exit()
    {
        player.anim.SetBool(animBoolName, false);
    }
    public virtual void AnimationFinishTrigger()
    {
        triggerCall = true;
    }
}
