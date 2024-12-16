using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    player player => GetComponentInParent<player>();
    private void AnimationTrigger()
    {
        player.AnimationTrigger();
    }
    private void AttackTrigger()
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
    private void ThrowSword()
    {
        SkillManager.Instance.Sword_Skill.CreateSword();
    }
}
