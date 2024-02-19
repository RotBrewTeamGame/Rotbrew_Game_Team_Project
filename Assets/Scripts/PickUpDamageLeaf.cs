using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDamageLeaf : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.IncreaseDamagePlantAmount(1);
            Destroy(gameObject);
        }
    }
}
