using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    
    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        Debug.Log("Updating health bar");
        slider.value = currentValue / maxValue;
    }
}
