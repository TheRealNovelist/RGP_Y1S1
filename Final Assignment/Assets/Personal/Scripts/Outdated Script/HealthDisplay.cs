using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Slider healthSlider;
    public Gradient healthGradient;
    public Health healthScript;
    public Image healthFill;

    public void Update()
    {
        healthSlider.value = healthScript.currentHealth;
        healthFill.color = healthGradient.Evaluate(healthSlider.normalizedValue);
    }
}
