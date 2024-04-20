using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalosController : MonoBehaviour
{
    public EnemyPatrolPoints patrol;
    public Animator anim;
    public bool melee;
    public bool lightning;

    private void Update()
    {
        if (patrol.patrolling || patrol.chasing)
        {
            anim.SetBool("walking", true); 
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }
}
