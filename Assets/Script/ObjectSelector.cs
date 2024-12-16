using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public LayerMask selectableLayers; // LayerMask to filter selectable layers

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse click
        {
            Debug.Log("Left mouse button clicked.");

            if (Camera.main == null)
            {
                Debug.LogError("Main Camera not found. Ensure the main camera is tagged as 'MainCamera'.");
                return;
            }
            else
            {
                Debug.Log("Main Camera found at position: " + Camera.main.transform.position);
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Line 14
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, selectableLayers);

            Debug.Log("Ray origin: " + ray.origin + ", direction: " + ray.direction);

            // Draw the ray in the Scene view for debugging
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);

            if (hit.collider != null)
            {
                Debug.Log("B?n ?ã ch?n: " + hit.collider.gameObject.name);
                // Perform actions with the selected object
                // Example: hit.collider.gameObject.GetComponent<YourComponent>()?.YourMethod();
            }
            else
            {
                Debug.Log("Không tìm th?y ??i t??ng nào ???c ch?n.");
            }
        }
    }
}