using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePotionCraft : MonoBehaviour
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
        if (GameManager.instance.damagePlantItemCount >= 1 && GameManager.instance.slimeBallItemCount >= 1)
        {
            GameManager.instance.damagePlantItemCount--;
            GameManager.instance.slimeBallItemCount--;
            GameManager.instance.firePotionItemCount++;
        }
    }
}
