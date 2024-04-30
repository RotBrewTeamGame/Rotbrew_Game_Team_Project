using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartDamage : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            Debug.Log("Dart triggered player");
            Destroy(gameObject);
        }
    }
}
