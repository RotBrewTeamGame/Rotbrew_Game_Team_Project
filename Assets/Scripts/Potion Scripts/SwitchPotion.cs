using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPotion : MonoBehaviour
{
    public GameObject damagePotionUI;
    public GameObject healthPotionUI;

    public bool damagePotionON;
    public bool healthPotionON;

    private void Start()
    {
        damagePotionUI.SetActive(true);
        healthPotionUI.SetActive(false);

        damagePotionON = true;
        healthPotionON = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DisableHealthPotion();
            EnableDamagePotion();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DisableDamagePotion();
            EnableHealthPotion();
        }
    }

    void EnableDamagePotion()
    {
        damagePotionUI.SetActive(true);
        damagePotionON = true;
        healthPotionON = false;
    }

    void DisableDamagePotion()
    {
        damagePotionUI.SetActive(false);
        damagePotionON = false;
        healthPotionON = true;
    }

    void EnableHealthPotion()
    {
        healthPotionUI.SetActive(true);
        healthPotionON = true;
        damagePotionON = false;
    }

    void DisableHealthPotion()
    {
        healthPotionUI.SetActive(false);
        healthPotionON = false;
        damagePotionON = true;
    }
}
