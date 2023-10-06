using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions_team_2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       
        //team_2_collection
        if (other.CompareTag("Team_2"))
        {
            // Handle the collection or destruction of the enemy tank
            Destroy(other.gameObject); // Destroy the enemy tank when collected\
            Destroy(gameObject);
        }
        if (other.CompareTag("boundary"))
        {
            Destroy(gameObject);
        }
    }
}
