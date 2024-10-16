using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallex : MonoBehaviour
{
    private GameObject cam;
    [SerializeField] private float parallexEffect;
    private float xPosition;
    private float length;
    // Start is called before the first frame update
    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = GameObject.Find("Main Camera");
        xPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceMoved = cam.transform.position.x * (1-parallexEffect);
        float distanceToMove = cam.transform.position.x * parallexEffect;
        transform.position = new Vector3(xPosition + distanceToMove, transform.position.y);

        if(distanceMoved > length + xPosition)
        {
            xPosition = xPosition + length;
        }else if(distanceMoved < xPosition - length) {
            xPosition = xPosition - length;
        }
    }
}
