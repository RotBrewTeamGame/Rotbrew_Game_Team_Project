using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePotionCraft : MonoBehaviour
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
        if (GameManager.instance.damagePlantItemCount >= 3)
        {
            GameManager.instance.damagePlantItemCount = GameManager.instance.damagePlantItemCount - 3;
            GameManager.instance.damagePotionItemCount++;
        }
    }
}
