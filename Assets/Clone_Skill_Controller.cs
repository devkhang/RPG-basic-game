using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone_Skill_Controller : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator anim;
    // Start is called before the first frame update
    [SerializeField] private float colorLoosingSpeed;
    [SerializeField] private Transform AttackCheck;
    [SerializeField] private float AttackCheckRadius = 0.8f;
    private float Clone_Timer;
    private Transform ClosestEnemy;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    public void Update()
    {
        Clone_Timer -= Time.deltaTime;
        if(Clone_Timer < 0)
        {
            sr.color = new Color(1, 1, 1, sr.color.a - (Time.deltaTime * colorLoosingSpeed));
            if(sr.color.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public void SetupClone(Transform new_transform,float Clone_Duration,bool _CanAttack)
    {
        if(_CanAttack)
        {
            anim.SetInteger("AttackNumber", Random.Range(1, 3));
        }
        transform.position = new_transform.position;
        Clone_Timer = Clone_Duration;
        FaceClosestTarget();
    }
    public void AnimationTrigger()
    {
        Clone_Timer = -0.1f;
    }
    public void AttackTrigger()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(AttackCheck.position,AttackCheckRadius);
        foreach (Collider2D hit in hits)
        {
            if (hit.GetComponent<enemy>() != null)
            {
                hit.GetComponent<enemy>().Damage();
            }
        }
    }
    private void FaceClosestTarget()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position,25);
        float closestDistance = Mathf.Infinity;
        foreach (Collider2D hit in hits)
        {
            if(hit.GetComponent<enemy>() != null)
            {
                float distanceToEnemy = Vector2.Distance(transform.position, hit.transform.position);
                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    ClosestEnemy = hit.transform;
                }
            }
        }
        if(ClosestEnemy != null)
        {
            if(transform.position.x > ClosestEnemy.position.x)
            {
                transform.Rotate(0, 180, 0);
            }
        }
    }
}
