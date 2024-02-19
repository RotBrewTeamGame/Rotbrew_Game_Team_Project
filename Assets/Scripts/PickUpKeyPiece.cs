using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKeyPiece : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.IncreaseKeyPieceAmount(1);
            Destroy(gameObject);
        }
    }
}
