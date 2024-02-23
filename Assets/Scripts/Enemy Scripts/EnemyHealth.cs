using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    public float maxHealth;

    public float fxStrength;
    public float fxSpeed;

    public Material damageFX;

    void Start()
    {
        maxHealth = enemyHealth;

        damageFX.SetFloat("_glow_speed", 0f);
        damageFX.SetFloat("_glow_strength", 0f);
    }

    public void TakeDamage(float damageAmount)
    {
        damageFX.SetFloat("_glow_speed", 5f);
        damageFX.SetFloat("_glow_strength", 0.06f);

        StartCoroutine("DamageFlashTimer");

        enemyHealth -= damageAmount;

        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        damageFX.SetFloat("_glow_speed", 0f);
        damageFX.SetFloat("_glow_strength", 0f);

        GetComponent<DropLoot>().InstantiateLoot(transform.position);
        this.gameObject.SetActive(false);
    }

    public IEnumerator DamageFlashTimer()
    {
        yield return new WaitForSeconds(0.5f);

        damageFX.SetFloat("_glow_speed", 0f);
        damageFX.SetFloat("_glow_strength", 0f);
    }
}
