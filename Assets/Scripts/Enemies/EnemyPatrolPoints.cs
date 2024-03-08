using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolPoints : MonoBehaviour
{
    public List<Transform> patrolPoints;

    public int patrolPointIndex = 0;
    public NavMeshAgent agent;
    public bool patrolling;
    public Transform player;

    private void Start()
    {
        patrolling = true;

        StartPatrol();
    }

    private void Update()
    {
        if (patrolling)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GoToNextWaypoint();
            }
        }
        else
        {
            ChasePlayer();
        }
    }

    public void StartPatrol()
    {
        agent.SetDestination(patrolPoints[0].position);
    }

    public void GoToNextWaypoint()
    {
        patrolPointIndex = (patrolPointIndex + 1) % patrolPoints.Count;

        agent.SetDestination(patrolPoints[patrolPointIndex].position);
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.transform.position);

        if (agent.remainingDistance > 8f)
        {
            patrolling = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            patrolling = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            patrolling = false;
        }
    }
}
