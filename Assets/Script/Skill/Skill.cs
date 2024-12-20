using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] protected float cooldown;
    protected float cooldownTimer;
    protected player Player;
    // Update is called once per frame
    protected virtual void Start()
    {
        if (playerManager.Instance == null)
        {
            Debug.LogError("PlayerManager.Instance is null. Ensure PlayerManager is initialized before Skill.");
            return;
        }
        Player = playerManager.Instance.player;
    }
    protected virtual void Update()
    {
        cooldownTimer -= Time.deltaTime;
    }
    public virtual bool CanUseSkill()
    {
        if(cooldownTimer <= 0)
        {
            UseSkill();
            cooldownTimer = cooldown;
            return true;
        }
        Debug.Log("skill is cooldown");
        return false;
    }
    public virtual void UseSkill()
    {
        
    }
}
