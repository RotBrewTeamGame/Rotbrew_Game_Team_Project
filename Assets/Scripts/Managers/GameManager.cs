using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int damagePlantItemCount;
    public int healthHerbItemCount;
    public int iceCrystalItemCount;
    public int slimeBallItemCount;
    public int keyPieceItemCount;
    public int damagePotionItemCount;
    public int healthPotionItemCount;
    public int frostPotionItemCount;
    public int firePotionItemCount;
    public int keyItemCount;

    public TextMeshProUGUI damagePlantQuantity;
    public TextMeshProUGUI healthHerbQuantity;
    public TextMeshProUGUI iceCrystalQuantity;
    public TextMeshProUGUI slimeBallQuantity;
    public TextMeshProUGUI keyPieceQuantity;
    public TextMeshProUGUI damagePotionQuantity;
    public TextMeshProUGUI healthPotionQuantity;
    public TextMeshProUGUI frostPotionQuantity;
    public TextMeshProUGUI firePotionQuantity;
    public TextMeshProUGUI keyQuantity;

    public GameObject keyUI;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.K))
        {
            IncreaseKeyPieceAmount(1);
        }
        */
    }

    public void IncreaseDamagePlantAmount(int amount)
    {
        damagePlantItemCount += amount;
        damagePlantQuantity.text = damagePlantItemCount.ToString();
    }

    public void IncreaseHealthHerbAmount(int amount)
    {
        healthHerbItemCount += amount;
        healthHerbQuantity.text = healthHerbItemCount.ToString();
    }

    public void IncreaseIceCrystalAmount(int amount)
    {
        iceCrystalItemCount += amount;
        iceCrystalQuantity.text = iceCrystalItemCount.ToString();
    }

    public void IncreaseSlimeBallAmount(int amount)
    {
        slimeBallItemCount += amount;
        slimeBallQuantity.text = slimeBallItemCount.ToString();
    }

    public void IncreaseKeyPieceAmount(int amount)
    {
        keyPieceItemCount += amount;
        keyPieceQuantity.text = keyPieceItemCount.ToString();
    }

    public void IncreaseDamagePotionAmount(int amount)
    {
        damagePotionItemCount += amount;
        damagePotionQuantity.text = damagePotionItemCount.ToString();
    }

    public void IncreaseHealthPotionAmount(int amount)
    {
        healthPotionItemCount += amount;
        healthPotionQuantity.text = healthPotionItemCount.ToString();
    }

    public void IncreaseFrostPotionAmount(int amount)
    {
        frostPotionItemCount += amount;
        frostPotionQuantity.text = frostPotionItemCount.ToString();
    }

    public void IncreaseFirePotionAmount(int amount)
    {
        firePotionItemCount += amount;
        firePotionQuantity.text = firePotionItemCount.ToString();
    }

    public void TurnOnKeyUI()
    {
        keyUI.SetActive(true);
    }

    public void IncreaseKeyAmount(int amount)
    {
        keyItemCount += amount;
        keyQuantity.text = keyItemCount.ToString();
    }
}
