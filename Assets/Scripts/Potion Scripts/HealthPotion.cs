using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPotion : MonoBehaviour
{
    public SwitchPotion potions;
    public PlayerHealth health;
    public PauseGame pauseGame;

    void Update()
    {
        if (pauseGame != null && !pauseGame.isPaused)
        {
            if (potions.healthPotionON && Input.GetKeyDown(KeyCode.Mouse1) && GameManager.instance.healthPotionItemCount != 0 && health.health != health.maxHealth)
            {
                health.HealHealth(1);
                GameManager.instance.healthPotionItemCount--;
            }
        }
    }
}
