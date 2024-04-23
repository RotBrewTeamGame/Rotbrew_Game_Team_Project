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


        if (patrol.chasing && patrol.agent.remainingDistance >= 0.5f)
        {
            StartCoroutine("MeleeAttack");
        }
    }

    IEnumerator MeleeAttack()
    {
        anim.SetBool("walking", false);
        anim.SetTrigger("melee");

        yield return new WaitForSeconds(2.5f);

        anim.SetBool("walking", true);
        anim.ResetTrigger("melee");
    }
}
