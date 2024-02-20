using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LootCount : MonoBehaviour
{
    public TMP_Text damageCount;
    public TMP_Text healthCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        damageCount.text = GameManager.instance.damagePlantItemCount.ToString();
        healthCount.text = GameManager.instance.healthHerbItemCount.ToString();
    }
}
