using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindSpeed : MonoBehaviour
{
	private int windSpeed = 0;
	public Text windSpeedText;
	
	Image windArrow;
	public static int rotation;
	

    // Start is called before the first frame update
    void Start()
    {
        windArrow = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        windSpeedText.text = windSpeed + " mph";
		
		if (Input.GetKeyDown(KeyCode.Tab)){
			windSpeed--;
		}
		
		windArrow.rectTransform.eulerAngles = new Vector3(0,0,rotation);
    }
}
