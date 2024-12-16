using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SkillManager Instance;
    public dash_skill Dash_Skill;
    public Clone_skill Clone_Skill;
    public Sword_Skill Sword_Skill;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance.gameObject); // Gi?t ??i t??ng n?u ?ã có m?t Instance khác
        }
    }
    private void Start()
    {
        Dash_Skill = GetComponent<dash_skill>();
        Clone_Skill = GetComponent<Clone_skill>();
        Sword_Skill = GetComponent<Sword_Skill>();
    }
}
