using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsText : MonoBehaviour
{
    private TextMeshProUGUI PtsText;

    private static int gPoints;
    public static int GPoints {
        get { return gPoints; }
        set
        {
            gPoints = value;
            SaveGame.Save(gPoints);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PtsText = GetComponent<TextMeshProUGUI>();
        //Set points display
        if (GPoints != null && GPoints >= 0)
        {
            PtsText.text = GPoints.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
