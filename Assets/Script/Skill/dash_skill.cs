using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash_skill : Skill
{
    public override void UseSkill()
    {
        base.UseSkill();
        Debug.Log("create clone behind");
    }
}
