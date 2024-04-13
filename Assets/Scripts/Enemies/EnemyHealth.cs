using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public GameObject enemyObject;
    public float enemyHealth;
    public float maxHealth;

    public Material baseEnemyMat;
    public Material damageFlashFX;
    public Material deathFX;

    //public GameObject deathVFXPrefab; // Reference to the death VFX prefab
    public EventReference enemyDissolveSFX; // FMOD EventReference for the enemy dissolve SFX

    private AudioManager audioManager;
    private Renderer enemyRenderer;

    public NavMeshAgent agent;
    public GameObject player;
    public bool damaged;
    public bool dead;

    void Start()
    {
        dead = false;
        damaged = false;

        maxHealth = enemyHealth;

        enemyRenderer = GetComponent<Renderer>();
        enemyRenderer.material = baseEnemyMat;

        audioManager = AudioManager.instance;
        agent = transform.parent.GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(float damageAmount)
    {
        enemyRenderer.material = damageFlashFX;

        StartCoroutine(DamageFlashTimer());

        enemyHealth -= damageAmount;

        agent.SetDestination(player.transform.position);

        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        dead = true;
        StartCoroutine(DeathTimer());
    }

    public IEnumerator DeathTimer()
    {
        float dissolveAmount = 0f;
        float dissolveSpeed = 3f; // Adjust speed as needed

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

        /*
        // Instantiate death VFX
        if (deathVFXPrefab != null)
        {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
        }
        */

        GetComponent<DropLoot>().InstantiateLoot(transform.position);
        enemyObject.SetActive(false);
    }

    public IEnumerator DamageFlashTimer()
    {
        damaged = true;

        yield return new WaitForSeconds(0.5f);

        enemyRenderer.material = baseEnemyMat;

        damaged = false;
    }
}
