using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LootCount : MonoBehaviour
{
    public TMP_Text damagePlantCount;
    public TMP_Text healthHerbCount;
    public TMP_Text damagePotionCount;
    public TMP_Text healthPotionCount;
    public TMP_Text iceCrystalCount;
    public TMP_Text slimeBallCount;
    public TMP_Text frostPotionCount;
    public TMP_Text firePotionCount;
    public TMP_Text keyPieceCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        damagePlantCount.text = GameManager.instance.damagePlantItemCount.ToString();
        healthHerbCount.text = GameManager.instance.healthHerbItemCount.ToString();
        iceCrystalCount.text = GameManager.instance.iceCrystalItemCount.ToString();
        slimeBallCount.text = GameManager.instance.slimeBallItemCount.ToString();
        damagePotionCount.text = GameManager.instance.damagePotionItemCount.ToString();
        healthPotionCount.text = GameManager.instance.healthPotionItemCount.ToString();
        frostPotionCount.text = GameManager.instance.frostPotionItemCount.ToString();
        firePotionCount.text = GameManager.instance.firePotionItemCount.ToString();
        keyPieceCount.text = GameManager.instance.keyPieceItemCount.ToString();
    }
}
