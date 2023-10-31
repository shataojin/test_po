using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    public GameObject objectPrefab;
    public GameObject aiPrefab;
    public float moveSpeed = 5.0f; // Adjust the speed of movement
    public string cubeName; // Assign a unique name for each button
    public GameObject spawnedObject;
    private float targetY = 2.0f;
    private ButtonTankBuild buttonManager;
    public float adajustX = 0.0f;
    public float adajustZ = 0.0f;
    public float SimpleboundaryMax = 150.0f;
    public float SimpleboundaryMin = 10.0f;
    private bool buttonPressed = false;

    // Get a reference to the ButtonManager script on start
    private void Start()
    {
        buttonManager = FindObjectOfType<ButtonTankBuild>();
    }

    void OnMouseDown()
    {
        // Check if any cube is already spawned
        if (!buttonManager.IsCubeSpawned())
        {
            // Set the flag to indicate that the button was pressed
            buttonPressed = true;
            // Debug.Log("Button pushed: " + cubeName);

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
            // Set the name for the spawned object
            spawnedObject.name = cubeName;
        }
    }

    void Update()
    {
        if (buttonPressed)
        {
           
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = 10; // Adjust the depth to be in front of other objects

                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);


                // Update the Y position to the targetY while keeping X and Z positions
                worldPosition.y = targetY;
                worldPosition.x = worldPosition.x * 20 + adajustX;
                worldPosition.z = worldPosition.z * 20 + adajustZ;

                // Move the spawned object smoothly toward the adjusted position
                spawnedObject.transform.position = Vector3.Lerp(spawnedObject.transform.position, worldPosition, moveSpeed * Time.deltaTime);

            // Debug.Log("Mouse Position (World): " + worldPosition);

            //switch to choosen tanks and destroy cube
            if (Input.GetMouseButtonDown(0) && !IsMouseOverButton())
            {
                // Build the AI at the current mouse position
                SpawnAIAtMousePosition();

                // Reset the flag to allow building another cube
                buttonPressed = false;

                // Destroy the cube
                Destroy(spawnedObject);
            }
            }

            //for testing click works with cube on also for cancel the spawn
            if (Input.GetMouseButtonDown(1) && !IsMouseOverButton())
            {
            // Reset the flag to allow building another cube
            buttonPressed = false;

            // Destroy the cube
            Destroy(spawnedObject);
        }
        
       
    }
    void SpawnAIAtMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10; // Adjust the depth to be in front of other objects
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.y = targetY;
        worldPosition.x = worldPosition.x * 20 + adajustX;
        worldPosition.z = worldPosition.z * 20 + adajustZ;

        // Instantiate the AI object at the mouse position
        Instantiate(aiPrefab, worldPosition, Quaternion.identity);
    }

    bool IsMouseOverButton()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider == GetComponent<Collider>();
           
        }

        return false;
    }
}
