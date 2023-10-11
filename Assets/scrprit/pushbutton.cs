using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    public GameObject objectPrefab;
    public float moveSpeed = 5.0f; // Adjust the speed of movement

    private GameObject spawnedObject;
    private float targetY = 2.0f;

    public float adajustX = 0.0f;
    public float adajustZ = 0.0f;
    public float SimpleboundaryMax = 150.0f;
    public float SimpleboundaryMin = 10.0f;

    void OnMouseDown()
    {
        Debug.Log("Button pushed");

        // Destroy the previously spawned object, if it exists
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10; // Adjust the depth to be in front of other objects

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Set the Y position to the targetY
        worldPosition.y = targetY;
        worldPosition.x = 0;
        worldPosition.z = 0;
        // Instantiate the object at the adjusted position
        spawnedObject = Instantiate(objectPrefab, worldPosition, Quaternion.identity);
    }

    void Update()
    {
        if (spawnedObject != null)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10; // Adjust the depth to be in front of other objects

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);


            // Update the Y position to the targetY while keeping X and Z positions
            worldPosition.y = targetY;
            worldPosition.x = worldPosition.x * 20 + adajustX;
            worldPosition.z = worldPosition.z * 20+ adajustZ;

            // Move the spawned object smoothly toward the adjusted position
            spawnedObject.transform.position = Vector3.Lerp(spawnedObject.transform.position, worldPosition, moveSpeed * Time.deltaTime);

           // Debug.Log("Mouse Position (World): " + worldPosition);

        if(spawnedObject.transform.position.z> SimpleboundaryMax)
            {
                mousePosition.z = -mousePosition.z;
                Debug.Log("SimpleboundaryMax " );
            }

           else if (spawnedObject.transform.position.z < SimpleboundaryMin)
            {
                mousePosition.z = -mousePosition.z;
                Debug.Log("SimpleboundaryMin" );
            }

        }
    }
}
