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
        PointsText.text = points.ToString();
    }
	
	public void SetPoints(int points) 
	{
		this.points = points;
	}
	
	public void AddPoints(int points) 
	{
		this.points += points;
	}
}
