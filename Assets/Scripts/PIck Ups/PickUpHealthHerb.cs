using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHealthHerb : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.IncreaseHealthHerbAmount(1);
            Destroy(gameObject);
        }
    }
}
