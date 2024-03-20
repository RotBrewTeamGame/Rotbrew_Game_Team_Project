using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPotion : MonoBehaviour
{
    public GameObject damagePotionUI;
    public GameObject healthPotionUI;
    public GameObject frostPotionUI;
    public GameObject firePotionUI;

    public bool damagePotionON;
    public bool healthPotionON;
    public bool frostPotionON;
    public bool firePotionON;

    [SerializeField]
    private int selectedPotion;

    private void Start()
    {
        damagePotionUI.SetActive(true);
        healthPotionUI.SetActive(false);
        frostPotionUI.SetActive(false);
        firePotionUI.SetActive(false);

        damagePotionON = true;
        healthPotionON = false;
        frostPotionON = false;
        firePotionON = false;
    }

    void Update()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        if (scrollWheel > 0f)
        {
            selectedPotion = Mathf.Clamp(selectedPotion + 1, 1, 4);
        }
        else if (scrollWheel < 0f)
        {
            selectedPotion = Mathf.Clamp(selectedPotion - 1, 1, 4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) || selectedPotion == 1)
        {
            DisableHealthPotion();
            EnableDamagePotion();
            DisableFrostPotion();
            DisableFirePotion();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || selectedPotion == 2)
        {
            DisableDamagePotion();
            EnableHealthPotion();
            DisableFrostPotion();
            DisableFirePotion();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || selectedPotion == 3)
        {
            DisableHealthPotion();
            EnableFrostPotion();
            DisableDamagePotion();
            DisableFirePotion();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || selectedPotion == 4)
        {
            DisableDamagePotion();
            EnableFirePotion();
            DisableFrostPotion();
            DisableDamagePotion();
        }
    }

    void EnableDamagePotion()
    {
        damagePotionUI.SetActive(true);
        damagePotionON = true;
        healthPotionON = false;
        frostPotionON = false;
        firePotionON = false;
    }

    void DisableDamagePotion()
    {
        damagePotionUI.SetActive(false);
        damagePotionON = false;
    }

    void EnableHealthPotion()
    {
        healthPotionUI.SetActive(true);
        healthPotionON = true;
        damagePotionON = false;
        frostPotionON = false;
        firePotionON = false;
    }

    void DisableHealthPotion()
    {
        healthPotionUI.SetActive(false);
        healthPotionON = false;
    }

    void EnableFrostPotion()
    {
        frostPotionUI.SetActive(true);
        damagePotionON = false;
        healthPotionON = false;
        frostPotionON = true;
        firePotionON = false;
    }

    void DisableFrostPotion()
    {
        frostPotionUI.SetActive(false);
        frostPotionON = false;
    }

    void EnableFirePotion()
    {
        firePotionUI.SetActive(true);
        healthPotionON = false;
        damagePotionON = false;
        frostPotionON = false;
        firePotionON = true;
    }

    void DisableFirePotion()
    {
        firePotionUI.SetActive(false);
        firePotionON = false;
    }
}
