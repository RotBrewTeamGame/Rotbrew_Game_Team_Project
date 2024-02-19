using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public PlayerHealth health;

    private void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.CompareTag("Player"))
        {
            collide.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}
