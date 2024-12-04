using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    player player => GetComponentInParent<player>();
    public void AnimationTrigger()
    {
        player.AnimationTrigger();
    }
    public void AttackTrigger()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(player.attackCheck.position,player.attackCheckRadius);
        foreach (Collider2D hit in hits)
        {
            if(hit.GetComponent<enemy>()!= null)
            {
                hit.GetComponent<enemy>().Damage();
            }
        }
    }
}
