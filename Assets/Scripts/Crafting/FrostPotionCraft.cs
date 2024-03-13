using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostPotionCraft : MonoBehaviour
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
        if (GameManager.instance.damagePlantItemCount >= 1 && GameManager.instance.iceCrystalItemCount >= 1)
        {
            GameManager.instance.damagePlantItemCount--;
            GameManager.instance.iceCrystalItemCount--;
            GameManager.instance.frostPotionItemCount++;
        }
    }
}
