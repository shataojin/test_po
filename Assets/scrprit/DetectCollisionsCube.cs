using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsCube : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("cube collider with wall");
        //collection with 

        if (other.CompareTag("boundary"))
        {
            Destroy(gameObject);
            Debug.Log("Destroy cube");
        }
    }
}
