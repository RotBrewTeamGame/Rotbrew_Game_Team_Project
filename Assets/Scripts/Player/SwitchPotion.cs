using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPotion : MonoBehaviour
{
    public GameObject damagePotionUI;
    public GameObject healthPotionUI;

    private void Start()
    {
        damagePotionUI.SetActive(true);
        healthPotionUI.SetActive(false);
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
    }

    void DisableDamagePotion()
    {
        damagePotionUI.SetActive(false);
    }

    void EnableHealthPotion()
    {
        healthPotionUI.SetActive(true);
    }

    void DisableHealthPotion()
    {
        healthPotionUI.SetActive(false);
    }
}
