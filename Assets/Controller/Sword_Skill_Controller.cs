using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Skill_Controller : MonoBehaviour
{
    [SerializeField] private float returnSpeed = 12;
    private Animator anim;
    private Rigidbody2D rb;
    private CircleCollider2D cd;
    private player player;
    private bool CanRotate = true;
    private bool isReturning;
    [Header("bounce info")]
    private float BounceSpeed;
    private bool isBouncing; 
    private int BounceAmount;
    [SerializeField]private  List<Transform> enemyTarget;
    private int TargetIndex;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();
    }
    public void SetUpSword(Vector2 lauchDir,float SwordGravity,player _player)
    {
        if(anim == null)
        {
            Debug.Log("kkk");
        }
        player = _player;
        rb.velocity = lauchDir;
        rb.gravityScale = SwordGravity;
        anim.SetBool("Rotation",true);
    }
    public void Update()
    {
        if (CanRotate)
        {
            transform.right = rb.velocity;
        }
        if (isReturning)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, returnSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, player.transform.position) < 1)
            {
                player.CatchSword();
            }
        }
        BounceLogic();
    }

    private void BounceLogic()
    {
        if (isBouncing && enemyTarget.Count > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, enemyTarget[TargetIndex].position, BounceSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, enemyTarget[TargetIndex].position) < 1)
            {
                TargetIndex++;
                BounceAmount--;
                if (BounceAmount <= 0)
                {
                    isBouncing = false;
                    isReturning = true;
                }
                if (TargetIndex >= enemyTarget.Count)
                {
                    TargetIndex = 0;
                }
            }
        }
    }

    public void SetupBounce(bool _isBouncing, int _amountOfBounces, float _bounceSpeed)
    {
        isBouncing = _isBouncing;
        BounceAmount = _amountOfBounces;
        BounceSpeed = _bounceSpeed;
    }
    public void ReturnSword()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        transform.parent = null;
        isReturning = true;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isReturning) return;
        if (collision.GetComponent<enemy>() != null)
        {
            if (isBouncing && enemyTarget.Count <=0)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 10);
                foreach (Collider2D hit in colliders)
                {
                    if (hit.GetComponent<enemy>() != null)
                    {
                        enemyTarget.Add(hit.transform);
                    }
                }

            }
        }
        StuckInto(collision);
    }

    private void StuckInto(Collider2D collision)
    {
        CanRotate = false;
        cd.enabled = false;
        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        if(isBouncing&&enemyTarget.Count>0) { return; }
        anim.SetBool("Rotation", false);
        transform.parent = collision.transform;
    }
}
