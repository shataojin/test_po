using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions_team_2 : MonoBehaviour
{
    public ParticleSystem explosionParticle;

    public int damageAmount = 10;
    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();

        //team_1_collection
        if (other.CompareTag("Team_2"))
        {
            //// Handle the collection or destruction of the enemy tank
            //Destroy(other.gameObject); // Destroy the enemy tank when collected\
            //Destroy(gameObject);
            if (health != null)
            {
               
                // Inflict a damage amount on the Health component of the colliding object
                health.TakeDamage(damageAmount);
                Debug.Log("did dmg to team_2");
                Destroy(gameObject);
                
            }

        }

        if (other.CompareTag("boundary"))
        {
            Destroy(gameObject);
        }
    }
}
