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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            craftingSystem.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            craftingSystem.SetActive(false);
        }
    }
}
