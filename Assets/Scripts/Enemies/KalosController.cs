using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalosController : MonoBehaviour
{
    public EnemyPatrolPoints patrol;
    public Animator anim;
    public bool melee;
    public bool lightning;
    public float meleeDistance;

    private void Update()
    {
        if (patrol.patrolling || patrol.chasing || !melee)
        {
            anim.SetBool("walking", true); 
        }

        if (patrol.chasing && (patrol.agent.remainingDistance < meleeDistance) && !melee)
        {
            melee = true;
            anim.SetBool("melee", true);
            anim.SetBool("walking", false);
        }
        else if (patrol.chasing && (patrol.agent.remainingDistance >= meleeDistance) && melee)
        {
            melee = false;
            anim.SetBool("melee", false);
            anim.SetBool("walking", true);
        }
    }

    /*IEnumerator MeleeAttack()
    {
        anim.SetBool("walking", false);
        anim.SetTrigger("melee");

        yield return new WaitForSeconds(2.5f);

        anim.SetBool("walking", true);
        anim.ResetTrigger("melee");
    }*/
}
