using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMaxHealth(int Health)
    {
        slider.maxValue = Health;
        
    }
    
    public void SetHealth(int Health)
    {
        slider.value = Health;
    }
}
