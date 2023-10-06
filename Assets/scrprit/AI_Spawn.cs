using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Spawn : MonoBehaviour
{
    public GameObject[] targetPrefab;
    public float time_range_start = 1.0f;
    public float time_range_end = 5.0f;
    public  float spawnLimitXLeft = 0;
    public  float spawnLimitXRight = 0;
    public float spawnLimitZLeft = 0;
    public float spawnLimitZRight = 0;
    public float spawnPosY = 0;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void SpawnRandomEnemy()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, Random.Range(spawnLimitZLeft, spawnLimitZRight));


        // instantiate ball at random spawn location
        int random_number = Random.Range(0, targetPrefab.Length);
        Instantiate(targetPrefab[random_number], spawnPos, targetPrefab[random_number].transform.rotation);
        Invoke("SpawnRandomEnemy", 5);
        //Random.Range(time_range_start, time_range_end)
    }
}
