using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_move_tank : MonoBehaviour
{
    private Camera mainCamera;  // Reference to the main camera
    private GameObject selectedObject;  // The currently selected object

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit object is movable (e.g., has a specific tag)
                if (hit.collider.CompareTag("Movable"))
                {
                    selectedObject = hit.collider.gameObject;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectedObject = null;
        }

        // Move the selected object if it's not null
        if (selectedObject != null)
        {
            // Get the mouse position in world coordinates
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectedObject.transform.position.z - mainCamera.transform.position.z));

            // Move the selected object to the mouse position
            selectedObject.transform.position = mousePos;
        }
    }
}
