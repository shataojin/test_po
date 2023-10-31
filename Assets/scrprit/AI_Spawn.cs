using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Spawn : MonoBehaviour
{
    public GameObject[] targetPrefab;
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

    // Start is called before the first frame update
    void Start()
    {
        if (enableRandomSpawn)
        {
            InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
        }
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
            Instantiate(targetPrefab[randomIndex], spawnPos, Quaternion.identity);
        }
    }
}
