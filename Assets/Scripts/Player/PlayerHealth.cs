using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public PlayerHealthBar healthBar;

    private FirstPersonMovement playerMovement;
    public GameObject deathScreen;

    void Start()
    {
        maxHealth = health;
        healthBar = GetComponent<PlayerHealthBar>();
        playerMovement = GetComponent<FirstPersonMovement>();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.DamageHealthBar(health, maxHealth);

        if (health <= 0)
        {
            Die();
        }
    }

    public void HealHealth(float healAmount)
    {
        health += healAmount;
        healthBar.Heal(health, maxHealth);
    }

    public void Die()
    {
        playerMovement.enabled = false;
        deathScreen.SetActive(true);
    }
}
