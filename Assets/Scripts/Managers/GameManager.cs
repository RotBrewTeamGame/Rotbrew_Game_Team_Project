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

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (keyPieceItemCount >= 4)
        {
            keyPieceItemCount = 3;
        }
    }

    public void IncreaseDamagePlantAmount(int amount)
    {
        damagePlantItemCount += amount;
        if (damagePlantQuantity != null)
        {
            damagePlantQuantity.text = damagePlantItemCount.ToString();
        }
        else
        {
            Debug.LogError("damagePlantQuantity is not assigned.");
        }
    }

    public void IncreaseHealthHerbAmount(int amount)
    {
        healthHerbItemCount += amount;
        if (healthHerbQuantity != null)
        {
            healthHerbQuantity.text = healthHerbItemCount.ToString();
        }
        else
        {
            Debug.LogError("healthHerbQuantity is not assigned.");
        }
    }

    public void IncreaseIceCrystalAmount(int amount)
    {
        iceCrystalItemCount += amount;
        if (iceCrystalQuantity != null)
        {
            iceCrystalQuantity.text = iceCrystalItemCount.ToString();
        }
        else
        {
            Debug.LogError("iceCrystalQuantity is not assigned.");
        }
    }

    public void IncreaseSlimeBallAmount(int amount)
    {
        slimeBallItemCount += amount;
        if (slimeBallQuantity != null)
        {
            slimeBallQuantity.text = slimeBallItemCount.ToString();
        }
        else
        {
            Debug.LogError("slimeBallQuantity is not assigned.");
        }
    }

    public void IncreaseKeyPieceAmount(int amount)
    {
        keyPieceItemCount += amount;
        if (keyPieceQuantity != null)
        {
            keyPieceQuantity.text = keyPieceItemCount.ToString();
        }
        else
        {
            Debug.LogError("keyPieceQuantity is not assigned.");
        }
    }

    public void IncreaseDamagePotionAmount(int amount)
    {
        damagePotionItemCount += amount;
        if (damagePotionQuantity != null)
        {
            damagePotionQuantity.text = damagePotionItemCount.ToString();
        }
        else
        {
            Debug.LogError("damagePotionQuantity is not assigned.");
        }
    }

    public void IncreaseHealthPotionAmount(int amount)
    {
        healthPotionItemCount += amount;
        if (healthPotionQuantity != null)
        {
            healthPotionQuantity.text = healthPotionItemCount.ToString();
        }
        else
        {
            Debug.LogError("healthPotionQuantity is not assigned.");
        }
    }

    public void IncreaseFrostPotionAmount(int amount)
    {
        frostPotionItemCount += amount;
        if (frostPotionQuantity != null)
        {
            frostPotionQuantity.text = frostPotionItemCount.ToString();
        }
        else
        {
            Debug.LogError("frostPotionQuantity is not assigned.");
        }
    }

    public void IncreaseFirePotionAmount(int amount)
    {
        firePotionItemCount += amount;
        if (firePotionQuantity != null)
        {
            firePotionQuantity.text = firePotionItemCount.ToString();
        }
        else
        {
            Debug.LogError("firePotionQuantity is not assigned.");
        }
    }

    public void IncreaseKeyAmount(int amount)
    {
        keyItemCount += amount;
        if (keyQuantity != null)
        {
            keyQuantity.text = keyItemCount.ToString();
        }
        else
        {
            Debug.LogError("keyQuantity is not assigned.");
        }
    }
}
