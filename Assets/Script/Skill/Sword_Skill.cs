using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Skill : Skill
{
    [Header("skill info")]
    [SerializeField] private GameObject swordprefab;
    [SerializeField] private Vector2 lauchDir;
    [SerializeField] private float SwordGravity;
}
