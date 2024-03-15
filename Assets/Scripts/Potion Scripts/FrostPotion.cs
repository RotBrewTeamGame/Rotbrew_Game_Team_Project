using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FrostPotion : MonoBehaviour
{
    public Material baseEnemyMAT;
    public Material freezeMAT;

    private void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.CompareTag("Enemy"))
        {
            Renderer enemyMAT = collide.gameObject.GetComponent<Renderer>();
            StartCoroutine(ColdEnemyEffect(enemyMAT));
            
            NavMeshAgent agent = collide.gameObject.GetComponentInParent<NavMeshAgent>();
            StartCoroutine(FreezeEffect(agent));
            //this.GetComponent<PotionSplash>().BreakPotion();
        }
    }

    IEnumerator FreezeEffect(NavMeshAgent ai)
    {
        ai.speed = 0;

        yield return new WaitForSeconds(4f);

        ai.speed = 3.5f;

        Destroy(gameObject);
    }

    IEnumerator ColdEnemyEffect(Renderer mat)
    {
        mat.material = freezeMAT;

        yield return new WaitForSeconds(4f);

        mat.material = baseEnemyMAT;
    }
}
