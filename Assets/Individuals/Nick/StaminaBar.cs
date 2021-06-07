using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider slider;
	public Gradient gradient;
	public Image fill;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void SetMaxStamina(float stamina) {
		slider.maxValue = stamina;
		slider.value = stamina;
		
		fill.color = gradient.Evaluate(1f);
	}
	
	public void SetStamina(float stamina) {
		slider.value = stamina;
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
}
