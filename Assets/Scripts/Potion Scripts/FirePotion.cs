using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePotion : MonoBehaviour
{
    public Material baseEnemyMAT;
    public Material fireMAT;
    private Renderer enemyRenderer;
    private GameObject collidedEnemy;
    private bool coroutineRunning = false;

    private void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.CompareTag("Enemy") && !coroutineRunning)
        {
            collidedEnemy = collide.gameObject;
            enemyRenderer = collidedEnemy.GetComponent<Renderer>();
            StartCoroutine(FireEffect());
        }
    }

    IEnumerator FireEffect()
    {
        coroutineRunning = true;
        float startTime = Time.time;

        while (Time.time - startTime < 5f)
        {
            if (collidedEnemy != null)
                collidedEnemy.GetComponent<EnemyHealth>().TakeDamage(1); // Damage the enemy
            yield return new WaitForSeconds(0.25f);
            enemyRenderer.material = baseEnemyMAT;
            yield return new WaitForSeconds(1f);
        }

        coroutineRunning = false;
        // Reset the material to baseEnemyMAT after the coroutine finishes
        if (enemyRenderer != null)
            enemyRenderer.material = baseEnemyMAT;
    }
}
