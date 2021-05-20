using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindSpeed : MonoBehaviour
{
	private int windSpeed = 0;
	public Text windSpeedText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        windSpeedText.text = windSpeed + " mph";
		
		if (Input.GetKeyDown(KeyCode.Tab)){
			windSpeed--;
		}
    }
}
