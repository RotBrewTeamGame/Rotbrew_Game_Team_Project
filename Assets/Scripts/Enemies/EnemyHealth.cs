using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject enemyObject;
    public float enemyHealth;
    public float maxHealth;

    public Material baseEnemyMat;
    public Material damageFlashFX;
    public Material deathFX;

    public GameObject deathVFXPrefab; // Reference to the death VFX prefab
    public EventReference enemyDissolveSFX; // FMOD EventReference for the enemy dissolve SFX

    private AudioManager audioManager;
    private Renderer enemyRenderer;

    void Start()
    {
        maxHealth = enemyHealth;

        enemyRenderer = GetComponent<Renderer>();
        enemyRenderer.material = baseEnemyMat;

        audioManager = AudioManager.instance;
    }

    public void TakeDamage(float damageAmount)
    {
        enemyRenderer.material = damageFlashFX;

        StartCoroutine(DamageFlashTimer());

        enemyHealth -= damageAmount;

        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        StartCoroutine(DeathTimer());
    }

    public IEnumerator DeathTimer()
    {
        float dissolveAmount = 0f;
        float dissolveSpeed = 0.5f; // Adjust speed as needed

        // Play dissolve SFX
        if (audioManager != null && !enemyDissolveSFX.IsNull)
        {
            audioManager.PlayOneShot(enemyDissolveSFX, transform.position);
        }

        while (dissolveAmount < 1f)
        {
            dissolveAmount += Time.deltaTime * dissolveSpeed;
            enemyRenderer.material.SetFloat("_VisibilityAmount", dissolveAmount);
            yield return null;
        }

        // Instantiate death VFX
        if (deathVFXPrefab != null)
        {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
        }

        GetComponent<DropLoot>().InstantiateLoot(transform.position);
        Destroy(enemyObject);
    }

    public IEnumerator DamageFlashTimer()
    {
        yield return new WaitForSeconds(0.5f);

        enemyRenderer.material = baseEnemyMat;
    }
}
