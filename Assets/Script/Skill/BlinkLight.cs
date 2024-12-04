using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    public Light lightSource;
    public float blinkInterval = 0.5f;

    void Start()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            lightSource.enabled = !lightSource.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
