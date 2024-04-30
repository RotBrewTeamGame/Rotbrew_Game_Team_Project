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
    public GameObject player;
    public float chasingDistance;
    public bool chasing;
    public PlayerHealth playerHealth;

    private void Start()
    {
        chasing = false;
        patrolling = true;
        playerHealth = player.GetComponent<PlayerHealth>();

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

        if (playerHealth.health <= 0)
        {
            chasing = false;
            patrolling = true;
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
        chasing = true;

        agent.SetDestination(player.transform.position);

        if (agent.remainingDistance > chasingDistance)
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
