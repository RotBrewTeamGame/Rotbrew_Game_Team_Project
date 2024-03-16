using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public EnemyHealth bossHealth;
    public EnemyPatrolPoints patrol;
    public GameObject bossUI;
    public Image healthBar;

    private void Start()
    {
        healthBar.fillAmount = float.MaxValue;
    }

    private void Update()
    {
        if (patrol.patrolling == false)
        {
            bossUI.SetActive(true);
        }
        else
        {
            bossUI.SetActive(false);
        }

        if (bossHealth.damaged)
        {
            DamageHealthBar(bossHealth.enemyHealth, bossHealth.maxHealth);
        }

        if (bossHealth.enemyHealth == 0)
        {
            bossUI.SetActive(false);
        }
    }

    public void DamageHealthBar(float currentValue, float maxValue)
    {
        healthBar.fillAmount = currentValue / maxValue;
    }
}
