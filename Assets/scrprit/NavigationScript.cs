using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    public List<Transform> targets; // List of possible targets
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Find the closest target initially
        Transform closestTarget = FindClosestTarget();

        if (closestTarget != null)
        {
            agent.destination = closestTarget.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Find the closest target in each frame and navigate towards it
        Transform closestTarget = FindClosestTarget();

        if (closestTarget != null)
        {
            agent.destination = closestTarget.position;
        }
    }

    // Function to find the closest target among the list
    Transform FindClosestTarget()
    {
        Transform closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (Transform potentialTarget in targets)
        {
            float distance = Vector3.Distance(transform.position, potentialTarget.position);
            if (distance < closestDistance)
            {
                closest = potentialTarget;
                closestDistance = distance;
            }
        }

        return closest;
    }
}
