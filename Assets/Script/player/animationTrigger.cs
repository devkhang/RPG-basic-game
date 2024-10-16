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
}
