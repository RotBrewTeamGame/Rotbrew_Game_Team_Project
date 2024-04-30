using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements.Experimental;


public class EnemyPatrol : MonoBehaviour
{
    public NavMeshAgent agent;
    public float range = 9;

    public Transform centrePoint;

    public bool patrolling;
    public GameObject player;
    public PlayerHealth playerHealth;

    void Start()
    {
        patrolling = true;
        playerHealth = player.GetComponent<PlayerHealth>();
    }


    void Update()
    {
        if (patrolling == true)
        {
            Patrol();
        }
        else
        {
            ChasePlayer();
        }

        if (playerHealth.health <= 0)
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

    void ChasePlayer()
    {
        agent.SetDestination(player.transform.position);

        if (agent.remainingDistance > 8f)
        {
            patrolling = true;
        }
    }

    void Patrol()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                agent.SetDestination(point);
            }
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 3.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }


}
