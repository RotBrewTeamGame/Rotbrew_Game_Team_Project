using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultistAttack : MonoBehaviour
{
    public EnemyPatrolPoints patrol;
    public EnemyDart dart;

    private void Start()
    {
        StartCoroutine(dart.ShootDart());
    }

    private void Update()
    {
        if (patrol.patrolling == false)
        {
            dart.isShooting = true;
        }
        else
        {
            dart.isShooting = false;
        }
    }
}
