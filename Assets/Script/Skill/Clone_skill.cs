using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone_skill : Skill
{
    [SerializeField] private GameObject clonePrefar;
    [SerializeField] private float clone_duration;
    [Space]
    [SerializeField] private bool _CanAttack;

    public void Create_Clone(Transform _clonePosition)
    {
        GameObject new_clone = Instantiate(clonePrefar);
        new_clone.GetComponent<Clone_Skill_Controller>().SetupClone(_clonePosition,clone_duration, _CanAttack);
    }
}
