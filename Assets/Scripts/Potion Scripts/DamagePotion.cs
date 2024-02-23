using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePotion : MonoBehaviour
{
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
            this.GetComponent<PotionSplash>().BreakPotion();
        }
    }
    */

    private void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.CompareTag("Enemy"))
        {
            collide.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
            this.GetComponent<PotionSplash>().BreakPotion();
        }
    }
}
