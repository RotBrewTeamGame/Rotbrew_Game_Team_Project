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
    public TextMeshProUGUI damagePlantQuantity;
    public TextMeshProUGUI healthHerbQuantity;
    public TextMeshProUGUI keyPieceQuantity;

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
}
