using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrengthBar : MonoBehaviour
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
	
	public void SetMaxStrength(float strength) {
		slider.maxValue = strength;
		slider.value = strength;
		
		fill.color = gradient.Evaluate(1f);
	}
	
	public void SetStrength(float strength) {
		slider.value = strength;
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
}
