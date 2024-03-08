using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public PlayerHealth health;
    public float damage;

    private void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.CompareTag("Player"))
        {
            collide.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
