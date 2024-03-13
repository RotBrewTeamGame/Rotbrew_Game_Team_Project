using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionCraft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        if (GameManager.instance.healthHerbItemCount >= 2)
        {
            GameManager.instance.healthHerbItemCount = GameManager.instance.healthHerbItemCount - 2;
            GameManager.instance.healthPotionItemCount++;
        }
    }
}
