using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    public float maxHealth;

    public 

    void Start()
    {
        maxHealth = enemyHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        enemyHealth -= damageAmount;

        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        GetComponent<DropLoot>().InstantiateLoot(transform.position);
        this.gameObject.SetActive(false);
    }
}
