using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCrafting : MonoBehaviour
{
    public GameObject craftingSystem;

    private void Start()
    {
        craftingSystem.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "CraftingStation")
        {
            craftingSystem.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "CraftingStation")
        {
            craftingSystem.SetActive(false);
        }
    }
}
