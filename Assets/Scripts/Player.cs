using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxStrength = 100;
	public float currentStrength;
	public float maxStamina = 100;
	public float currentStamina;
	
	public float staminaRegenRate = 0.012f;
	public float pullStrength = 0.4f;
	
	public bool reverse = false;
	public int reverseCount = 0;

	public StrengthBar strengthBar;
	public StaminaBar staminaBar;

    // Start is called before the first frame update
    void Start()
    {
		currentStrength = 0.0f;
		strengthBar.SetMaxStrength(maxStrength);
		currentStamina = maxStamina;
		staminaBar.SetMaxStamina(maxStamina);
    }

    // Update is called once per frame
    void Update()
    {
		//Initial pull of bow by pushing "space"
		if (Input.GetKeyDown(KeyCode.Space)) {
			//Reset strength bar
			reverse = false;
			currentStrength = 0.0f;
			strengthBar.SetMaxStrength(maxStrength);
			pullStrength = 0.2f;
			
			//Pulling the bow requires some initial stamina
			Fatigue(20.0f);
		}
		
		//While holding "space" strength bar moves while stamina depletes
		if (Input.GetKey("space")) {
			Pull(pullStrength);
			Fatigue(0.02f); //TODO! Keep as flat rate?
		}
		
		UpdateStamina();
		
    }
	
	//STAMINA BAR UPDATES
	void UpdateStamina() {
		//When stamina reaches 0, slow down regen rate
		if (currentStamina <= 0) {
			staminaRegenRate = 0.007f;
		}else if (currentStamina >= 25 && currentStamina < 60) { //Once stamina reaches 25 again, increase regen rate
			staminaRegenRate = 0.01f;
		} else if (currentStamina >= 60) { //Once stamina reaches 60 again, increase regen rate
			staminaRegenRate = 0.012f;
		}
		
		//Continually recharge stamina guage
		if (currentStamina < 100) {	
			currentStamina+= staminaRegenRate;
			staminaBar.SetStamina(currentStamina);
		}
	}

	//Method for draining stamina guage
	void Fatigue(float staminaLoss)
	{
		currentStamina -= staminaLoss;
		//Don't allow stamina to go below -10
		if (currentStamina < -10) {
			currentStamina = -10;
		}
		staminaBar.SetStamina(currentStamina);
	}
	
	//Method for determining current strength
	void Pull(float strength) {
		//Based on current strength, decrease pull strength rate
		switch (currentStrength) {
			case 50:
				pullStrength *= 0.5f;
				break;
			case 75:
				pullStrength *= 0.85f;
				break;
		}
		
		//In reverse, lower strength.  This happens after strength reaches 100 for the first time.
		if (reverse) {
			currentStrength -= strength;
			switch (reverseCount) {
				case 0:  //On the first reverse, do not go lower than 50 strength
					if (currentStrength < 50) {
						reverseCount++;
						reverse = false;
					}
					break;
				case 1:  //On the second reverse, do not go lower than 60 strength
					if (currentStrength < 60) {
						reverseCount++;
						reverse = false;
					}
					break;
				case 2:  //On the third or more reversals, do not go lower than 65 strength
					if (currentStrength < 65) {
						reverse = false;
					}
					break;
			}
		} else { //Increase strength
			currentStrength += strength;
			if (currentStrength >= 100) {
				reverse = true;
			}
		}
		if (currentStamina <= 0.0f) {
			currentStrength = 0.0f;
		}
		strengthBar.SetStrength(currentStrength);
	}
		
}
