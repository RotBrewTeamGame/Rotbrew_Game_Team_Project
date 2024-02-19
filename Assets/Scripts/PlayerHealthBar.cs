using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider healthSlider;

    private void Start()
    {
        healthSlider.value = healthSlider.maxValue;
    }
    private void Update()
    {

    }

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        healthSlider.value = currentValue / maxValue;
    }
}
