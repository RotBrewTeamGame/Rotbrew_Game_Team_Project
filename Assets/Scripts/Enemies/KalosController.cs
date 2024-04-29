using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalosController : MonoBehaviour
{
    public List<GameObject> lightningAreas = new List<GameObject>();
    public List<Lightning> lightningScripts = new List<Lightning>();
    public EnemyPatrolPoints patrol;
    public Animator anim;
    public bool melee;
    public bool lightning;
    public float meleeDistance;
    public float lightningDistance;

    private void Start()
    {
        foreach (var obj in lightningAreas)
        {
            obj.SetActive(false);
        }
    }

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

        if (patrol.chasing && (patrol.agent.remainingDistance > lightningDistance))
        {
            anim.SetTrigger("lightning");
            StartCoroutine("LightningAttack");
        }
    }

    IEnumerator LightningAttack()
    {
        foreach (var obj in lightningAreas)
        {
            obj.SetActive(true);
        }

        yield return new WaitForSeconds(3f);

        foreach (var obj in lightningAreas)
        {
            obj.SetActive(false);
        }
    }
}
