using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePotion : MonoBehaviour
{
    public Material baseEnemyMAT;
    public GameObject vfxPrefab; // Reference to the VFX prefab
    public float burningMaterialRate = 0.5f; // Initial value of BurningMaterialRate
    public float flamesRate = 0.5f; // Initial value of FlamesRate
    public float sparksRate = 0.5f; // Initial value of SparksRate

    private GameObject collidedEnemy;
    private bool coroutineRunning = false;

    private void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.CompareTag("Enemy") && !coroutineRunning)
        {
            collidedEnemy = collide.gameObject;
            StartCoroutine(FireEffect());
        }
    }

    IEnumerator FireEffect()
    {
        coroutineRunning = true;
        float startTime = Time.time;

        Debug.Log("Fire Effect started");

        // Calculate the center position of the enemy
        Vector3 enemyCenter = collidedEnemy.GetComponent<Collider>().bounds.center;

        // Instantiate VFX prefab at the center position of the enemy
        GameObject vfxInstance = Instantiate(vfxPrefab, enemyCenter, Quaternion.identity);

        // Parent the VFX to the collided enemy
        vfxInstance.transform.parent = collidedEnemy.transform;

        Debug.Log("VFX prefab instantiated");

        // Access the ParticleSystem component of the VFX prefab
        ParticleSystem vfxParticleSystem = vfxInstance.GetComponent<ParticleSystem>();

        while (Time.time - startTime < 5f && collidedEnemy != null)
        {
            // Damage the enemy if it's still valid
            if (collidedEnemy != null)
            {
                collidedEnemy.GetComponent<EnemyHealth>()?.TakeDamage(1);
            }
            else
            {
                Debug.Log("Enemy object is null.");
            }

            yield return new WaitForSeconds(0.25f);

            // Check if the enemy renderer is still valid before changing material
            if (collidedEnemy != null && collidedEnemy.TryGetComponent<Renderer>(out Renderer enemyRenderer))
            {
                enemyRenderer.material = baseEnemyMAT;
            }
            else
            {
                Debug.Log("Enemy renderer is null.");
            }

            yield return new WaitForSeconds(1f);
        }

        Debug.Log("Damage applied and waiting to change VFX values");

        // Change the values of the floats to 0 after 5 seconds
        if (vfxParticleSystem != null)
        {
            var main = vfxParticleSystem.main;
            main.startSize = 0f;
            main.startSpeed = 0f;
            main.startColor = Color.black;
        }
        else
        {
            Debug.Log("VFX ParticleSystem component is null.");
        }

        // Change the values of the floats to 0 after 5 seconds
        if (vfxParticleSystem != null)
        {
            var main = vfxParticleSystem.main;
            main.startSize = 0f;
            main.startSpeed = 0f;
            main.startColor = Color.black;
        }
        else
        {
            Debug.Log("VFX ParticleSystem component is null.");
        }

        Debug.Log("VFX values changed");

        // Wait for 3 more seconds
        yield return new WaitForSeconds(3f);

        // Destroy the VFX prefab
        Destroy(vfxInstance);

        Debug.Log("VFX prefab destroyed");

        coroutineRunning = false;
    }
}