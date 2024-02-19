using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToBeContinued : MonoBehaviour
{
    public GameObject bossDoor;
    public GameObject tBCScreen;
    public Rigidbody playerRB;

    // Update is called once per frame
    void Update()
    {
        EnableScreen();
    }

    private void EnableScreen()
    {
        if (bossDoor == null && GameManager.instance.keyPieceItemCount == 3)
        {
            tBCScreen.SetActive(true);
            playerRB.isKinematic = true;
        }
    }
}
