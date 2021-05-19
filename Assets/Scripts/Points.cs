using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
	private int points = 0;
	public Text PointsText;
	
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		//TODO! Update points based on targets hit
        PointsText.text = points.ToString();
		
		if (Input.GetKeyDown(KeyCode.Tab)){
			points++;
		}
    }
}
