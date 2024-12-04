using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerOneWayPlatform : MonoBehaviour
{
    private GameObject currentPlatformOneWay;
    [SerializeField] private CapsuleCollider2D playerCollider;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if(currentPlatformOneWay != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform")){
            currentPlatformOneWay = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentPlatformOneWay = null;
        }
    }
    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentPlatformOneWay.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider,platformCollider);
        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider,false);
    }
}
