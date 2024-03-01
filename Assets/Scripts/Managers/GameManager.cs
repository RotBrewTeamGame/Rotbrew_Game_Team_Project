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
    public int keyPieceItemCount;
    public int damagePotionItemCount;
    public int healthPotionItemCount;
    public int keyItemCount;

    public TextMeshProUGUI damagePlantQuantity;
    public TextMeshProUGUI healthHerbQuantity;
    public TextMeshProUGUI keyPieceQuantity;
    public TextMeshProUGUI damagePotionQuantity;
    public TextMeshProUGUI healthPotionQuantity;
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
        if (Input.GetKeyDown(KeyCode.K))
        {
            IncreaseKeyPieceAmount(1);
        }
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
