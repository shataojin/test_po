using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_team_1_turret : MonoBehaviour
{
    

    public float rotationSpeed = 5f;
    public float fireRate = 2f;
    private float nextFireTime = 0f;
    public float bulletSpeed = 5.0f;

    public Transform firePoint; // The point where bullets will be spawned
    public GameObject bulletPrefab; // Prefab of the bullet object
    private Transform currentTarget;

   

    private void Start()
    {
       
    }
    private void Update()
    {
      
        
            
            FindClosestTarget();

            if (currentTarget != null)
            {
                // Calculate the direction to the current target
                Vector3 targetDirection = currentTarget.position - transform.position;

                // Calculate the rotation step
                float step = rotationSpeed * Time.deltaTime;

                // Rotate the turret gun towards the current target
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDirection);

                // Check if it's time to fire
                if (Time.time >= nextFireTime)
                {
                    Shoot(); // Implement your firing logic here
                    nextFireTime = Time.time + fireRate;
                }
            }
        
    }

    private void FindClosestTarget()
    {
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag("Team_2");

        if (targetObjects.Length == 0)
        {
            currentTarget = null;
            return;
        }

        float closestDistance = float.MaxValue;

        foreach (GameObject targetObject in targetObjects)
        {
            float distance = Vector3.Distance(transform.position, targetObject.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                currentTarget = targetObject.transform;
            }
        }
    }

    private void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // Instantiate a bullet at the fire point
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Get the Rigidbody of the bullet
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            // Apply a force to the bullet to make it move forward
            rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        }
    }
}
