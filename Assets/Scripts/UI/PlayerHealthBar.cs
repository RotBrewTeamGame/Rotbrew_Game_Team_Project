using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Image healthBar;

    private void Start()
    {
        healthBar.fillAmount = float.MaxValue;
    }
    private void Update()
    {

    }

    public void DamageHealthBar(float currentValue, float maxValue)
    {
        healthBar.fillAmount = currentValue / maxValue;
    }

    public void Heal(float currentValue, float maxValue)
    {
        healthBar.fillAmount = currentValue / maxValue;
    }
}
