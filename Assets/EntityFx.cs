using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFx : MonoBehaviour
{
    private SpriteRenderer sr;
    // Start is called before the first frame update
    [Header("flash FX")]
    [SerializeField] Material hitmat;
    private Material originMaterial;

    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originMaterial = sr.material;
    }
    private IEnumerator FlashFX()
    {
        sr.material = hitmat;
        yield return new WaitForSeconds(0.2f);
        sr.material = originMaterial;
    }
    private void RedColorBlink()
    {
        if(sr.color != Color.white)
        {
            sr.color = Color.white;
        }
        else
        {
            sr.color = Color.red;
        }
    }
    private void CancelRedBlink()
    {
        CancelInvoke();
        sr.color = Color.white;
    }
}
