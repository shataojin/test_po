using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            // Handle the collection or destruction of the enemy tank
            Destroy(other.gameObject); // Destroy the enemy tank when collected\
            Destroy(gameObject);
        }
    }
}
