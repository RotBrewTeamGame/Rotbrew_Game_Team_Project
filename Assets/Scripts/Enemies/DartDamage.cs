using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartDamage : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(this);
        }
        else
        {
            Destroy(this);
        }
    }
}
