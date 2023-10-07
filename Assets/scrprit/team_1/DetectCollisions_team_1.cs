using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions_team_1 : MonoBehaviour
{
    public int damageAmount=10;
    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();
      
        //team_1_collection
        if (other.CompareTag("Team_1"))
        {
            //// Handle the collection or destruction of the enemy tank
            //Destroy(other.gameObject); // Destroy the enemy tank when collected\
            //Destroy(gameObject);
            if (health != null)
            {
                // Inflict a damage amount on the Health component of the colliding object
                health.TakeDamage(damageAmount);
                Debug.Log("did dmg to team_1");
            }

        }
 
        if (other.CompareTag("boundary"))
        {
            Destroy(gameObject);
        }
    }
}
