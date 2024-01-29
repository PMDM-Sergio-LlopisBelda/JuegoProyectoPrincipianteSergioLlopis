using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealCooldownBar : MonoBehaviour
{
    public Slider slider;
    public Text setText;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMaxCooldown(float MaxCooldown)
    {
        slider.maxValue = MaxCooldown;

    }

    public void SetCooldown(float Cooldown)
    {
        slider.value = Cooldown;
        setText.text = Cooldown.ToString("F2");
    }
}
