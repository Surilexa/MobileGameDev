using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Slider barSliderTop;
    public Slider barSliderBottom;

    public void setMaxHealth(int maxHealth)
    {
        barSliderTop.maxValue = maxHealth;
        barSliderBottom.maxValue = maxHealth;
    }
    public void SetHealth(int Health)
    {
        barSliderTop.value = Health;
    }
    private void FixedUpdate()
    {
        if (barSliderTop.value <= barSliderBottom.value) {
            barSliderBottom.value -= 5 * Time.deltaTime;
        }
    }
}
