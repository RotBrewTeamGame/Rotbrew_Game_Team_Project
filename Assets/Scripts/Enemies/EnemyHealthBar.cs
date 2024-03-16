using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public EnemyHealth health;
    public EnemyPatrolPoints patrol;
    public GameObject enemyUI;
    public Image healthBar;

    private void Start()
    {
        healthBar.fillAmount = float.MaxValue;
    }

    private void Update()
    {
        if (patrol.patrolling == false)
        {
            enemyUI.SetActive(true);
        }
        else
        {
            enemyUI.SetActive(false);
        }

        if (health.damaged)
        {
            DamageHealthBar(health.enemyHealth, health.maxHealth);
        }

        if (health.enemyHealth == 0)
        {
            enemyUI.SetActive(false);
        }
    }

    public void DamageHealthBar(float currentValue, float maxValue)
    {
        healthBar.fillAmount = currentValue / maxValue;
    }
}
