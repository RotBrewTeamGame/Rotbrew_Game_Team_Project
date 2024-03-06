using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    public float maxHealth;

    public Material baseEnemyMat;
    public Material damageFlashFX;
    public Material deathFX;

    void Start()
    {
        maxHealth = enemyHealth;

        this.GetComponent<Renderer>().material = baseEnemyMat;
    }

    public void TakeDamage(float damageAmount)
    {
        this.GetComponent<Renderer>().material = damageFlashFX;

        StartCoroutine("DamageFlashTimer");

        enemyHealth -= damageAmount;

        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        this.GetComponent<Renderer>().material = deathFX;

        StartCoroutine("DeathTimer");
    }

    public IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(0.5f);

        GetComponent<DropLoot>().InstantiateLoot(transform.position);
        this.gameObject.SetActive(false);
    }

    public IEnumerator DamageFlashTimer()
    {
        yield return new WaitForSeconds(0.5f);

        this.GetComponent<Renderer>().material = baseEnemyMat;
    }
}
