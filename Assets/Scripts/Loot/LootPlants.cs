using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootPlants : MonoBehaviour
{
    public List<GameObject> plants;
    public int currentObject = 0;
    public bool inTrigger = false;
    public int plant;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            inTrigger = false;
        }
    }

    void Update()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (currentObject < plants.Count)
            {
                Destroy(plants[currentObject]);
                currentObject++;
                if (plant == 0)
                {
                    GameManager.instance.damagePlantItemCount++;
                }
                if (plant == 1)
                {
                    GameManager.instance.healthHerbItemCount++;
                }
            }
        }
    }
}
