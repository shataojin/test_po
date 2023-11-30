using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AI_Spawn : MonoBehaviour
{
    //public ParticleSystem explosionParticle;
  
    public GameObject[] targetPrefab;
    public Health health;
    public float time_range_start = 1.0f;
    public float time_range_end = 5.0f;
    public float spawnLimitXLeft = 0;
    public float spawnLimitXRight = 0;
    public float spawnLimitZLeft = 0;
    public float spawnLimitZRight = 0;
    public float spawnPosY = 0;

    public bool enableRandomSpawn = true; // Add a boolean variable for enabling/disabling random spawning

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    private bool isAlive = true; // Track whether the tank is alive

    // Start is called before the first frame update
    void Start()
    {
        if (enableRandomSpawn)
        {
            InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
        }

        //health = GetComponent<Health>();
        //// Subscribe to the tank's death event
        //if (health != null)
        //{
        //    isAlive = true;
        //}
        //else
        //{
        //    isAlive = false;
        //    OnTankDeath();
        //}
    }

    void SpawnRandomEnemy()
    {
        if (enableRandomSpawn)
        {
            // Generate a random spawn position
            Vector3 spawnPos = new Vector3(
                Random.Range(spawnLimitXLeft, spawnLimitXRight),
                spawnPosY,
                Random.Range(spawnLimitZLeft, spawnLimitZRight)
            );

            // Instantiate a random prefab at the random spawn location
            int randomIndex = Random.Range(0, targetPrefab.Length);
            GameObject spawnedObject = Instantiate(targetPrefab[randomIndex], spawnPos, Quaternion.identity);
            Debug.Log("Spawned a " + spawnedObject.name);

            //// EnergyCost
            //if (randomIndex == 0)
            //{
            //    Debug.Log("Spawned the second prefab: " + spawnedObject.name);
            //}
            //if (randomIndex == 1)
            //{
            //    Debug.Log("Spawned the second prefab: " + spawnedObject.name);
            //}
            //if (randomIndex == 2)
            //{
            //    Debug.Log("Spawned the second prefab: " + spawnedObject.name);
            //}
        }


    }

    //void EnergyCost()
    //{
    //    if (randomIndex == 1)
    //    {
    //        Debug.Log("Spawned the second prefab: " + spawnedObject.name);
    //    }
    //}

    //private void OnTankDeath()
    //{
    //    isAlive = false; // Set the tank as not alive

    //    // Play the explosion and fireworks particles at the tank's position
    //    if (explosionParticle != null)
    //    {
    //        explosionParticle.transform.position = transform.position;
    //        explosionParticle.Play();
    //    }

      
    //}
}
