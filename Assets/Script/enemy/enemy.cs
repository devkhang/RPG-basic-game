using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy : entity
{
    [SerializeField] protected LayerMask whatisPlayer;
    [Header("move info")]
    public float moveSpeed;
    public float idleTime;
    public float battleTime;

    [Header("attack info")]
    public float attackDistance;
    [HideInInspector]public float lastTimeAttack;
    public float cooldownAttack;

    [Header("Stun info")]
    public Vector2 stunDirection;
    public float stunTime;
    protected bool canBeStun;
    [SerializeField] protected GameObject counterImage;


    protected enemyStateMachine stateMachine { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new enemyStateMachine();
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position,new Vector3(transform.position.x + attackDistance * facingDir,transform.position.y));
    }
    public void OpenCounterAttackWindow()
    {
        canBeStun = true;
        counterImage.SetActive(true);
    }
    public void CloseCounterAttackWindow()
    {
        canBeStun=false;
        counterImage.SetActive(false);
    }
    public virtual bool canBeStunned()
    {
        if (canBeStun)
        {
            CloseCounterAttackWindow();
            return true;
        }
        return false;
    }
    public virtual RaycastHit2D isPlayerDetected()=>Physics2D.Raycast(wallCheck.position,Vector2.right*facingDir,50,whatisPlayer);
    public virtual void AnimationFinishTriger()=>stateMachine.currentState.AnimationFinishTrigeer();
}
