using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript_team_1 : MonoBehaviour
{

    public List<Transform> targets; // List of possible targets
    private NavMeshAgent agent;
    private Transform currentTarget;
    private bool targetsChanged = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Find the closest target initially
        currentTarget = FindClosestTarget();

        if (currentTarget != null)
        {
            agent.destination = currentTarget.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // You can skip the FindClosestTarget call if targets haven't changed
        if (targetsChanged)
        {
            currentTarget = FindClosestTarget();
            targetsChanged = false;
        }

        if (currentTarget != null)
        {
            agent.destination = currentTarget.position;
        }
    }

    // Function to find the closest target among the list
    private Transform FindClosestTarget()
    {
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag("Team_2");

        if (targetObjects.Length == 0)
        {
            return null;
        }

        float closestDistance = float.MaxValue;
        Transform closestTarget = null;

        foreach (GameObject targetObject in targetObjects)
        {
            float distance = Vector3.Distance(transform.position, targetObject.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = targetObject.transform;
            }
        }

        return closestTarget;
    }
}
