using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPotion : MonoBehaviour
{
    public SwitchPotion potions;
    public PlayerHealth health;

    void Update()
    {
        if (potions.healthPotionON && Input.GetKeyDown(KeyCode.Mouse1))
        {
            health.HealHealth(1);
        }
    }
}
