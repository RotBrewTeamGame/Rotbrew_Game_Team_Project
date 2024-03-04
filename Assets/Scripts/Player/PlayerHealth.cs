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

    public UnityEngine.UI.Image damage;
    public bool isDamageCooldown = false;
    public float damageCooldownDuration = 1.0f;


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
        StartCoroutine(ChangeAlphaCoroutine());
        StartCoroutine(StartDamageCooldown());


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

    IEnumerator ChangeAlphaCoroutine()
    {
        if (!isDamageCooldown)
        {
            isDamageCooldown = true;
            Color startColor = damage.color;
            Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0.25f);

            damage.color = targetColor;

            yield return new WaitForSeconds(0.5f);

            damage.color = startColor;
            isDamageCooldown = false;
        }
    }

    IEnumerator StartDamageCooldown()
    {
        isDamageCooldown = true;
        yield return new WaitForSeconds(damageCooldownDuration);
        isDamageCooldown = false;
    }

}
